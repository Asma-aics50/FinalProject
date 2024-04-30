﻿namespace FinalProject.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<PatientHistory> PatientHistory { get; set; }
        public List<Bill> Bills { get; set; }   

    }
}
