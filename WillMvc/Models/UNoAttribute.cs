using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WillMvc.Models
{
    public class UNoAttribute : DataTypeAttribute
    {
        public UNoAttribute() : base(DataType.Text)
        {
            ErrorMessage = "Only 1-9";
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            Regex reg = new Regex("^[1-9]+$");
            return reg.IsMatch(Convert.ToString(value));
        }
    }
}