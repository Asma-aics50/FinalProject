﻿using FinalProject.Models;

namespace FinalProject.IRepositry
{
    public interface IMedicalAnalysisRepositry
    {
        public void Create(MedicalAnaylsis medicalAnaylsis);
        public void Update(MedicalAnaylsis medicalAnaylsis);
        public void Delete(int id);
        public MedicalAnaylsis GetById(int id);
        public List<MedicalAnaylsis> GetAll();

    }
}
