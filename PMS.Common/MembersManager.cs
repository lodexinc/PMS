using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Common
{
    // Unit of Work Design Pattern
    public class MembersManager : BaseEntityManager<Member>
    {
        #region Members
        public void Register(string FirstName, string LastName, string UserName, string Password, string University, string EmailAddress)
        {
            var member = new Member()
            {
                FirstName = FirstName,
                LastName = LastName,
                UserName = UserName,
                University = University,
                EmailAddress = EmailAddress
            };

            Encrypt encrypt = new Encrypt();
            encrypt.Key = UserName;
            encrypt.Message = Password;
            member.Password = encrypt.EncryptString();

            Insert(member);
        }

        public bool Authenticate(string UserName, string Password)
        {
            var member = CurrentContext.Members.FirstOrDefault(m => m.UserName.Equals(UserName, StringComparison.InvariantCultureIgnoreCase));
            if (member == null)
                return false;

            Encrypt encrypt = new Encrypt();
            encrypt.Key = member.UserName;
            encrypt.Message = member.Password;
            string decryptedPassword = encrypt.DecryptString();
            if(decryptedPassword.Equals(Password, StringComparison.InvariantCultureIgnoreCase))
                return true;
            else
                return false;
        }

        public Member GetMember(string UserName)
        {
            return CurrentContext.Members.FirstOrDefault(m => m.UserName.Equals(UserName, StringComparison.InvariantCultureIgnoreCase));
        }

        public void ChangePassword(string UserName,string OldPassword, string NewPassword)
        {
            Encrypt encrypt = new Encrypt();
            var oldEntity = GetMember(UserName);
            encrypt.Key = UserName;
            encrypt.Message = oldEntity.Password;
            string decryptedPassword = encrypt.DecryptString();
            if (!OldPassword.Equals(decryptedPassword, StringComparison.InvariantCultureIgnoreCase))
                throw new Exception("Old Password does not match");

            encrypt.Message = NewPassword;
            oldEntity.Password = encrypt.EncryptString();
            Update(oldEntity);
        }

        #endregion
    }
}
