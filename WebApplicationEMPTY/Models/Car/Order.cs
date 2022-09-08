using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApplicationEMPTY.Models.Car
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name = "Введите имя")]
        [StringLength(20)]
        [Required (ErrorMessage = "Длина имени не более 20 символов")]
        public string name  { get; set; }
        [Display(Name = "Введите фамилию")]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина  не более 20 символов")]
        public  string surname { get; set; }
        [Display(Name = "Введите адрес")]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина не более 20 символов")]
        public string address { get; set; }
        [Display(Name = "Введите телефон")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина не более 20 символов")]
        public string phone { get; set; }
        [Display(Name = "Введите Email")]
        [StringLength(20)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Длина не более 20 символов")]
        public string email { get; set; }
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        [ScaffoldColumn(false)]
        public virtual List<OrderDetail> orderDetails { get; set; }
    }
}
