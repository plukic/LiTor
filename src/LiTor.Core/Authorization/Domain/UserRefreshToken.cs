using LiTor.SharedKernel;

namespace LiTor.Core.Authorization
{
    public class UserRefreshToken : BaseEntity<string>
    {
        #region Scalar properties

        public DateTime CreationDateTimeUtc { get; set; }
        public DateTime ExpirationDateTimeUtc { get; set; }
        public string UserId { get; set; }

        #endregion Scalar properties

        #region Navigation properties

        public User User { get; set; }

        #endregion Navigation properties
    }
}
