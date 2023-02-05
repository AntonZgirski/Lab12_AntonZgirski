namespace Lab12.Models
{
  [Serializable]
  public class BaseModel
  {
    public string Name { get; set; }
    public string SecondName { get; set; }
    public string Age { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }

    public BaseModel()
    {    }
    public BaseModel(string name, string sname, string age, string email, string password, string number)
    {
      Name = name;
      SecondName = sname;
      Age = age;
      Email = email;
      Password = password;
      PhoneNumber = number;     
    }
  }
}
