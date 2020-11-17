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
    public partial class CreateCharacter : Form
    {
        private readonly CharacterInsert _request = new CharacterInsert
        {
            Biography = "None",
            BirthDate = DateTime.Now,
            FirstName = "John",
            LastName = "Doe",
            MediaFile = new MCharacterMediaFile(),
            Occupation = "None",
            Family = new MFamily()
        };

        private readonly APIService _characterApiService = new APIService("Character");
        private readonly APIService _familyApiService = new APIService("Family");

        private readonly CharacterForm CharacterFamilyForm = CharacterForm.GetForm;

        public CreateCharacter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(ofd.FileName);

                    var imageByte = File.ReadAllBytes(fi.FullName);
                    _request.MediaFile.Thumbnail = imageByte;

                    this.pictureBox1.Image = ImageWorker.ConvertFromByteArray(imageByte);
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                try
                {
                    var family = await _familyApiService.GetById<MFamily>(int.Parse(this.comboBox1.SelectedValue.ToString()));
                    _request.FirstName = this.textBox1.Text;
                    _request.LastName = this.textBox2.Text;
                    _request.Biography = this.textBox3.Text;
                    _request.Occupation = this.textBox4.Text;
                    _request.BirthDate = this.dateTimePicker1.Value;
                    _request.Family = family;

                    await _characterApiService.Insert<MCharacter>(_request);
                    await CharacterFamilyForm.LoadCharacters();
                    
                    MessageBox.Show("Success");

                    CreateCharacter.ActiveForm.Close();
                }
                catch
                {
                    MessageBox.Show("Error insert");
                }
            }
        }

        private async void CreateCharacter_Load(object sender, EventArgs e)
        {
            errorProvider1.ContainerControl = this;

            try
            {
                var data = await _familyApiService.Get<List<MFamily>>(null);
                this.comboBox1.ValueMember = "Id";
                this.comboBox1.DisplayMember = "Name";
                this.comboBox1.DataSource = data;
            }
            catch
            {
                MessageBox.Show("Error family load");
            }
        }


        private bool validateFirstName()
        {
            bool status = true;
            if(textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "First name required");
                status = false;
            }
            else
                errorProvider1.SetError(textBox1, "");
            return status;
        }

        private bool validateLastName()
        {
            bool status = true;
            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Last name required");
                status = false;
            }
            else
                errorProvider1.SetError(textBox2, "");
            return status;
        }

        private bool validateBiography()
        {
            bool status = true;
            if (textBox3.Text == "")
            {
                errorProvider1.SetError(textBox3, "Biography required");
                status = false;
            }
            else
                errorProvider1.SetError(textBox3, "");
            return status;
        }

        private bool validateOccupation()
        {
            bool status = true;
            if (textBox4.Text == "")
            {
                errorProvider1.SetError(textBox4, "Occupation required");
                status = false;
            }
            else
                errorProvider1.SetError(textBox4, "");
            return status;
        }

        private bool validateImage()
        {
            bool status = true;
            if (_request.MediaFile.Thumbnail == null)
            {
                MessageBox.Show("Image required");
                status = false;
            }
            return status;
        }

        private bool validateForm()
        {
            bool finalStatus = false;

            if(validateFirstName() && validateLastName() && validateOccupation() && validateBiography() && validateImage())
            {
                finalStatus = true;
            }

            return finalStatus;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            validateFirstName();
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            validateLastName();
        }


        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            validateOccupation();
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            validateBiography();
        }

    }
}
