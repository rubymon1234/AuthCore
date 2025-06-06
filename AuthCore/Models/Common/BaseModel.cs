﻿using System.ComponentModel.DataAnnotations;

namespace ShoppyWeb.Models.Common
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string CreatedBy { get; set; }
    }
}
