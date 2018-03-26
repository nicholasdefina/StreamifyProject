using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace streamify   //this model validator checks if date is in the future
{
  [AttributeUsage(AttributeTargets.Property |
    AttributeTargets.Field, AllowMultiple = false)]
  sealed public class PastDate : ValidationAttribute
  {
    public override bool IsValid(object value)
    {
      bool result = false;
      // Add validation logic here
      if (value is DateTime)
      {
        if ((DateTime)value <= DateTime.UtcNow)  //good if DateTime value before today's date
        {
          result = true;
        }
      }
      return result;
    }
  }
}