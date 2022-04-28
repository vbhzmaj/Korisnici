using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfUserAdmin.Model
{
    public class User : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region Fields

        private int id;
        private string userName;
        private string userPass;
        private bool isAdmin;
        
        private Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
        
        #endregion

        #region Properties
        public int Id
        {
            get { return id; }
            set
            {
                if (id == value)
                {
                    return;
                }
                id = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Id"));
            }
        }
        public string UserName
        {
            get { return userName; }
            set
            {
                if (userName == value)
                {
                    return;
                }
                userName = value;

                List<string> errors = new List<string>();
                bool valid = true;

                if (value == null || value == "")
                {
                    errors.Add("Username cannot be empty.");
                    SetErrors("UserName", errors);
                    valid = false;
                }

                if (!Regex.Match(value, @"^[a-zA-Z_0-9]+$").Success)
                {
                    errors.Add("Username can only contain letters, numbers and underscore.");
                    SetErrors("UserName", errors);
                    valid = false;
                }

                if (valid)
                {
                    ClearErrors("UserName");
                }

                OnPropertyChanged(new PropertyChangedEventArgs("UserName"));
            }
        }
        public string UserPass
        {
            get { return userPass; }
            set
            {
                if (userPass == value)
                {
                    return;
                }
                userPass = value;

                List<string> errors = new List<string>();
                bool valid = true;

                if (value == null || value == "")
                {
                    errors.Add("Password cannot be empty.");
                    SetErrors("UserPass", errors);
                    valid = false;
                }

                if (!Regex.Match(value, @"^[a-zA-Z_0-9]+$").Success)
                {
                    errors.Add("Password can only contain letters, numbers and underscore.");
                    SetErrors("UserPass", errors);
                    valid = false;
                }

                if (value.Length < 8 )
                {
                    errors.Add("Password cannot be shorter than 8 characters.");
                    SetErrors("UserPass", errors);
                    valid = false;
                }

                if (value.Length > 30)
                {
                    errors.Add("Password cannot be longer than 30 characters.");
                    SetErrors("UserPass", errors);
                    valid = false;
                }

                if (valid)
                {
                    ClearErrors("UserPass");
                }

                OnPropertyChanged(new PropertyChangedEventArgs("UserPass"));
            }
        }
        public bool IsAdmin
        {
            get { return isAdmin; }

            set
            {
                if (isAdmin == value)
                {
                    return;
                }
                isAdmin = value;

                List<string> errors = new List<string>();
                bool valid = true;

                string valueS = value.ToString();

                

                if (valueS == null || valueS == "")
                {
                    errors.Add("IsAdmin cannot be empty.");
                    SetErrors("IsAdmin", errors);
                    valid = false;
                }


                //if (!Regex.Match(valueS, @"^[0-1]+$").Success)
                if (!value.Equals(true) && !value.Equals(false))
                {
                    errors.Add("Only numbers 0 and 1 are allowed");
                    SetErrors("IsAdmin", errors);
                    valid = false;
                }


                if (valid)
                {
                    ClearErrors("IsAdmin");
                }

                OnPropertyChanged(new PropertyChangedEventArgs("IsAdmin"));
            }
        }
         
        #endregion

        #region Constructor
        public User(string userName, string userPass, bool isAdmin)
        {
            this.UserName = userName;
            this.UserPass = userPass;
            this.IsAdmin = isAdmin;

        }

        public User(int id, string userName, string userPass, bool isAdmin)
        {
            this.UserName = userName;
            this.UserPass = userPass;
            this.IsAdmin = isAdmin;
            this.id = id;
        }

        public User()
        {
            UserName = "";
            UserPass = "";
            IsAdmin = false;
        }

        public User Clone()
        {
            User clonedUser = new User();
            clonedUser.UserName = this.UserName;
            clonedUser.UserPass = this.UserPass;
            clonedUser.IsAdmin = this.IsAdmin;
            clonedUser.Id = this.Id;

            return clonedUser;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            User objUser = (User)obj;

            if (objUser.Id == this.Id) return true;

            return false;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion

        #region Data Access
        public static User FindLogUser(string username, string pass)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Users", conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User logUser = new User
                                {
                                    id = reader.GetInt32(0),
                                    userName = reader.GetString(1),
                                    userPass = Decrypt(reader.GetString(2), "my_Crypto_EncDec"),
                                    isAdmin = reader.GetBoolean(3)
                                };

                                if (username == logUser.userName && pass == logUser.userPass)
                                {
                                    return logUser;
                                }
                            }
                        }
                        return null;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }
        public static User GetUserFromResultSet(SqlDataReader reader)
        {
            User user = new User((int)reader["ID"], (string)reader["UserName"], Decrypt((string)reader["UserPass"], "my_Crypto_EncDec"), (bool)reader["IsAdmin"]);
            return user;
        }
        public bool UpdateUser()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
                    conn.Open();

                    SqlCommand command = new SqlCommand("UPDATE Users SET UserName=@UserName, UserPass=@UserPass, IsAdmin=@IsAdmin WHERE ID=@Id", conn);

                    SqlParameter UserNameParam = new SqlParameter("@UserName", SqlDbType.NVarChar);
                    UserNameParam.Value = this.UserName;
                    
                    SqlParameter UserPassParam = new SqlParameter("@UserPass", SqlDbType.NVarChar);
                    UserPassParam.Value = Encrypt(this.UserPass, "my_Crypto_EncDec");

                    SqlParameter IsAdminParam = new SqlParameter("@IsAdmin", SqlDbType.Bit, 1);
                    IsAdminParam.Value = this.IsAdmin;

                    SqlParameter myParam = new SqlParameter("@Id", SqlDbType.Int, 11);
                    myParam.Value = this.Id;

                    command.Parameters.Add(UserNameParam);
                    command.Parameters.Add(UserPassParam);
                    command.Parameters.Add(IsAdminParam);
                    command.Parameters.Add(myParam);

                    int rows = command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool InsertUser()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
                    conn.Open();

                    SqlCommand command = new SqlCommand("INSERT INTO Users(UserName, UserPass, IsAdmin) VALUES(@UserName, @UserPass, @IsAdmin); SELECT IDENT_CURRENT('Users');", conn);

                    SqlParameter UserNameParam = new SqlParameter("@UserName", SqlDbType.NVarChar);
                    UserNameParam.Value = this.UserName;

                    SqlParameter UserPassParam = new SqlParameter("@UserPass", SqlDbType.NVarChar);
                    UserPassParam.Value = Encrypt(this.UserPass, "my_Crypto_EncDec");

                    SqlParameter IsAdminParam = new SqlParameter("@IsAdmin", SqlDbType.Bit, 1);
                    IsAdminParam.Value = this.IsAdmin;

                    command.Parameters.Add(UserNameParam);
                    command.Parameters.Add(UserPassParam);
                    command.Parameters.Add(IsAdminParam);
                    
                    var id = command.ExecuteScalar();

                    if (id != null)
                    {
                        Console.WriteLine(id);
                        this.Id = Convert.ToInt32(id);
                    }
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }

        }
        public int Save()
        {
            if (Id == 0)
            {
                if (InsertUser())
                { return 1; }
                else { return 0; }
            }
            else
            {
                if(UpdateUser())
                return 2;
                else { return 0; }
            }
        }

        #endregion

        #region error manipulation

        private void SetErrors(string propertyName, List<string> propertyErrors)
        {
            errors.Remove(propertyName);
            errors.Add(propertyName, propertyErrors);
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
        private void ClearErrors(string propertyName)
        {
            errors.Remove(propertyName);
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
        public bool HasErrors
        {
            get
            {
                return (errors.Count > 0);
            }
        }
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return (errors.Values);
            }
            else
            {
                if (errors.ContainsKey(propertyName))
                {
                    return (errors[propertyName]);
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

        #region converters
        public static string Encrypt(string input, string key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string input, string key)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        #endregion

        #region events

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
        #endregion

    }
}

