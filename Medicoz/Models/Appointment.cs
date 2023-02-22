﻿using Medicoz.Enums;
using System.ComponentModel.DataAnnotations;

namespace Medicoz.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        [StringLength(maximumLength: 30)]

        public string FullName { get; set; }
        [StringLength(maximumLength:30)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        [StringLength(maximumLength: 50)]
        public string Email { get; set; }
        [StringLength (maximumLength: 250)]
        public string Message { get; set; }
        public Status Status { get; set; }
        public DateTime AppointmentTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
