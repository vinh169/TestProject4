namespace TestProject.Model
{
    public class User
    {
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public string User_Passkey { get; set; }
        public string User_Token { get; set; }
        public int Status { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public string Full_name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Update_Date { get; set; }
        public string Created_User { get; set; }
        public string Update_User { get; set; }
        public int Profession_Id { get; set; }
        public int Collaborator_Id { get; set; }
        public int Active {get; set; }
    }
}
