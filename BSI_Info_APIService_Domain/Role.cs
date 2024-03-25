using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace BSI_Info_APIService_Domain
{
    public partial class Role
    {
        [Key]
        [Column("RoleID")]
        public int RoleId { get; set; }

        [StringLength(50)]
        public string RoleName { get; set; } = null!;

        [ForeignKey("RoleId")]
        [InverseProperty("Roles")]
        public virtual ICollection<User> Usernames { get; set; } = new List<User>();
    }
}