using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using template.Domain.Models;

namespace template.Infra.Data.Mappings {
    public class ExampleMapping : IEntityTypeConfiguration<EntityBase> {
        public void Configure (EntityTypeBuilder<EntityBase> builder) {
            builder.HasKey (key => key.Id);
            builder.Property (p => p.Id).ValueGeneratedOnAdd ();
            // builder.Property (p => p.Body).HasMaxLength (int.MaxValue).IsRequired ();
            // builder.Property (p => p.isBodyHTML).HasMaxLength (int.MaxValue).IsRequired ();
            // builder.Property (p => p.SendDate);
            // builder.Property (p => p.Subject).HasMaxLength (200).IsRequired ();

            // builder.Property (p => p.Priority).IsRequired ()
            //     .HasConversion (new EnumToStringConverter<MailPriority> ());

            // builder.Property (p => p.Status).IsRequired ()
            //     .HasConversion (new EnumToStringConverter<EmailStatusEnum> ());

            // builder.HasOne (p => p.Credential)
            //     .WithMany (p => p.EmailMessages)
            //     .HasForeignKey (p => p.CredentialId).IsRequired ();

            // builder.HasOne (p => p.Sender)
            //     .WithMany (p => p.EmailMessages)
            //     .HasForeignKey (p => p.SenderId).IsRequired ();

            // builder.HasMany (p => p.Attachments)
            //     .WithOne (p => p.EmailMessage)
            //     .HasForeignKey (p => p.EmailMessageId).IsRequired ();

            // builder.HasOne (p => p.SmtpConfig)
            //     .WithMany (p => p.EmailMessages)
            //     .HasForeignKey (p => p.SmtpConfigId).IsRequired ();

            // //inverse property
            // builder.HasMany (p => p.EmailMessageReceivers)
            //     .WithOne (p => p.EmailMessage)
            //     .HasForeignKey (p => p.EmailMessageId).IsRequired ();

            // builder.ToTable ("EmailMessage");           
        }
    }
}