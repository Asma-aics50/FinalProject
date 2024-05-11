﻿using FinalProject.Models;

namespace FinalProject.IRepositry
{
    public interface IPatientHistoryRepositry
    {
        public void Create(PatientHistory patientHistory);
        public void Update(PatientHistory patientHistory);
        public void Delete(int id);
        public PatientHistory Get(int id);
        public List<PatientHistory> GetAll();

    }
}