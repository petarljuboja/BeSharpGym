namespace BeSharpGym.Models
{
    public partial class Member
    {
        public int  MemberId {get; set;}
        public string  FullName {get; set;}
        public string  Email {get; set;}
        public  DateTime RegistrationDate {get; set;}
        public  DateTime LastLoginDate {get; set;}
        public bool  IsPremiumMember {get; set;}
        public string  MembershipStatus {get; set;}
   

    public Member()
    {
        if (FullName == null)
        {
            FullName = "";
        }
         if (Email == null)
        {
            Email = "";
        }
         if (MembershipStatus == null)
        {
            MembershipStatus = "";
     
        }  
       }
    }
}