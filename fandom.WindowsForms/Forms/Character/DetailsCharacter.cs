using fandom.Model;
using fandom.Model.Models;
using fandom.Model.Requests;
using fandom.WindowsForms.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fandom.WindowsForms.Forms.Character
{
    public partial class DetailsCharacter : Form
    {
        private readonly int _characterId;
        private readonly APIService _characterApiService = new APIService("Character");
        private CharacterUpdateRequest request = new CharacterUpdateRequest
        {
            Biography = "",
            BirthDate = DateTime.Now,
            FirstName = "",
            LastName = "",
            Occupation = "",
            MediaFile = new MCharacterMediaFile()
        };

        private class ValueHolder
        {
            public Image initialImage { get; set; }
            public string firstName { get; set; }
            public string biography { get; set; }
            public string lastName { get; set; }
            public string birthDate { get; set; }
            public string occupation { get; set; }

            public ValueHolder(Image img, string first, string last, string birth, string occupation,string bio)
            {
                this.initialImage = img;
                this.firstName = first;
                this.lastName = last;
                this.biography = bio;
                this.birthDate = birth;
                this.occupation = occupation;
            }
        }

        private  ValueHolder characterInitialData;

        public DetailsCharacter(int id)
        {
            InitializeComponent();
            _characterId = id;
        }

        private async void DetailsCharacter_Load(object sender, EventArgs e)
        {
            var data = await _characterApiService.GetById<MCharacter>(_characterId);

            BindData(data);

        }

        private void BindData(MCharacter character)
        {
            characterInitialData = new ValueHolder(ImageWorker.ConvertFromByteArray(character.CharacterMediaFile.Thumbnail),
                character.FirstName,
                character.LastName,
                character.BirthDate.ToString("dd-MM-yyyy"),
                character.Occupation,
                character.Biography
                );

            this.pictureBox1.Image = ImageWorker.ConvertFromByteArray(character.CharacterMediaFile.Thumbnail);
            this.textBox1.Text = $"{character.FirstName} {character.LastName}";
            this.textBox2.Text = character.Biography;
            this.textBox3.Text = character.BirthDate.ToString("dd-MM-yyyy");
            this.textBox4.Text = character.Occupation;
        }

 

        private void button1_Click(object sender, EventArgs e)
        {
            EditButtonClickedActions();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CancelButtonClickedActions();
        }

        private void EditButtonClickedActions()
        {
            this.button1.Visible = false;
            this.button2.Visible = true;
            this.button3.Visible = true;
            this.button4.Visible = true;

            this.textBox1.ReadOnly = false;
            this.textBox1.BackColor = Color.White;

            this.textBox2.ReadOnly = false;
            this.textBox2.BackColor = Color.White;

            this.textBox3.ReadOnly = false;
            this.textBox3.BackColor = Color.White;

            this.textBox4.ReadOnly = false;
            this.textBox4.BackColor = Color.White;

            this.dateTimePicker1.Visible = true;
            this.dateTimePicker1.Value = DateTime.Parse(characterInitialData.birthDate);

        }

        private void CancelButtonClickedActions()
        {
            this.pictureBox1.Image = characterInitialData.initialImage;
            this.textBox1.Text = $"{characterInitialData.firstName} {characterInitialData.lastName}";
            this.textBox2.Text = characterInitialData.biography;
            this.textBox3.Text = characterInitialData.birthDate;
            this.textBox4.Text = characterInitialData.occupation;

            this.button1.Visible = true;
            this.button2.Visible = false;
            this.button3.Visible = false;
            this.button4.Visible = false;

            this.textBox1.ReadOnly = true;
            this.textBox1.BackColor = Color.WhiteSmoke;

            this.textBox2.ReadOnly = true;
            this.textBox2.BackColor = Color.WhiteSmoke;

            this.textBox3.ReadOnly = true;
            this.textBox3.BackColor = Color.WhiteSmoke;

            this.textBox4.ReadOnly = true;
            this.textBox4.BackColor = Color.WhiteSmoke;

            this.dateTimePicker1.Visible = false;

            this.pictureBox1.Image = characterInitialData.initialImage;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var fullName = textBox1.Text.Split(' ');
            if (fullName.Length > 1 && fullName.Length < 3)
            {
                request.FirstName = fullName[0];
                request.LastName = fullName[1];
            }
            request.Biography = textBox2.Text;
            request.BirthDate = dateTimePicker1.Value;
            request.Occupation = textBox4.Text;

           await _characterApiService.Update<MCharacter>(_characterId, request);
            MessageBox.Show("Character updated");
            DetailsCharacter.ActiveForm.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(ofd.FileName);

                    var imageByte = File.ReadAllBytes(fi.FullName);
                    request.MediaFile.Thumbnail = imageByte;

                    this.pictureBox1.Image = ImageWorker.ConvertFromByteArray(imageByte);
                }
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            await _characterApiService.Delete<MCharacter>(_characterId);
            MessageBox.Show("Deleted");
            DetailsCharacter.ActiveForm.Close();
        }
    }
}
