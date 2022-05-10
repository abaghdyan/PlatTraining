﻿namespace PlatTraining.Dal.Entities
{
    public class SomeTenantData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IndexState State { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}