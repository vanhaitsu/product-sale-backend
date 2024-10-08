﻿using Microsoft.AspNetCore.Identity;
using Repositories.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Entities
{
	[Table("Account")]
	public class Account : IdentityUser<Guid>
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public Gender? Gender { get; set; }
		public DateOnly? DateOfBirth { get; set; }
		public string? Address { get; set; }
		public string? Image { get; set; }

		// Refresh Token
		public string? RefreshToken { get; set; }
		public DateTime? RefreshTokenExpiryTime { get; set; }

		// Email verification
		public string? VerificationCode { get; set; }
		public DateTime? VerificationCodeExpiryTime { get; set; }

		// Base Entity
		// Note: This class cannot inherit from 2 classes (BaseEntity, IdentityUser) at the same 
		public DateTime CreationDate { get; set; }
		public Guid? CreatedBy { get; set; }
		public DateTime? ModificationDate { get; set; }
		public Guid? ModifiedBy { get; set; }
		public DateTime? DeletionDate { get; set; }
		public Guid? DeletedBy { get; set; }
		public bool IsDeleted { get; set; } = false;
        public Guid CartID { get; set; }
		public ICollection<Cart> Cart { get; set; } = new List<Cart>();
        public ICollection<Order>? Orders { get; set; } = new List<Order>();
        public ICollection<Notification>? Notifications { get; set; } = new List<Notification>();
        public ICollection<ChatMessage>? ChatMessages { get; set; } = new List<ChatMessage>();
        public ICollection<FeedBack>? FeedBacks { get; set; } = new List<FeedBack>();

    }
}
