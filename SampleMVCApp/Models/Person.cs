using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SampleMVCApp.Models
{
    public class Person : IValidatableObject
    {
        public int PersonId { get; set; }
        [Display(Name = "名前")]
        //[Required(ErrorMessage = "必須項目です。")]
        public string Name { get; set; }
        [Display(Name = "メールアドレス")]
        //[EmailAddress(ErrorMessage = "メールアドレスが必要です。")]
        public string Mail { get; set; }
        [Display(Name = "年齢")]
        //[Range(0, 200, ErrorMessage = "ゼロ以上200以下の値にしてください。")]
        public int Age { get; set; }

        [Display(Name = "投稿")]
        public ICollection<Message> Message { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Name == null)
            {
                yield return new ValidationResult("名前は必須項目です。");
            }

            if (Mail == null || (Mail != null && !Regex.IsMatch(Mail, "[a-zA-Z0-9.+-_%]+@[a-zA-Z0-9.-]+")))
            {
                yield return new ValidationResult("メールアドレスが必要です。");
            }

            if(Age < 0)
            {
                yield return new ValidationResult("年齢はマイナスにはできません。");
            }
        }
    }
}
