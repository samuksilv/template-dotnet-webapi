using Microsoft.EntityFrameworkCore;

namespace template.Infra.Data.DBContexts
{
    public class templateDbContext : DbContext
    {

        public templateDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating (ModelBuilder modelBuilder) {            
                            
            // modelBuilder.ApplyConfiguration (new EmailAddressMapping ());
            // modelBuilder.ApplyConfiguration (new CredentialMapping ());
            // modelBuilder.ApplyConfiguration (new EmailAttachmentMapping ());
            // modelBuilder.ApplyConfiguration (new SmtpConfigurationMapping ());
            // modelBuilder.ApplyConfiguration (new EmailMessageReceiverMapping ());
            // modelBuilder.ApplyConfiguration (new EmailMessageMapping ());
            // modelBuilder.ApplyConfiguration (new ReceiverMapping ());
        }
    }
}