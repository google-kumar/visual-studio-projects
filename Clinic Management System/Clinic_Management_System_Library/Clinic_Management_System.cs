using System;


namespace Clinic_Management_System
{
    //Only the declaration of the methods are done in this Library, definitions are done in the Repositary Class 
   
    //Login Menu validates the User ID and Password

    public interface I_Login_Menu     
    {
        public bool Username_check(string username);
        public bool Password_check(string username,string password);
    }


    //only registered  users can log into Home Menu 
    public interface I_Home_Menu
    {
        public void View_Doctors();
        public void Add_Patient();
        public void Schedule_Appointment();
        public void Cancel_Appointment(string patientid);
    }

    //Only Admin of the Management or Developer of the Code Can Move into Admin menu, With special User Id which can be enterred in the User Login screen itself,
    //and can Add Doctor and User Informations 
    public interface I_Admin_Menu
    {
        public void Add_User();
        public void Add_Doctors();
    }
}