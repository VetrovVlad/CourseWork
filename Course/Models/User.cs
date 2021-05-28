namespace Course.Models
{
    /// <summary>
    /// Defines the <see cref="User" />.
    /// </summary>
    internal class User
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Defines the login.
        /// </summary>
        private string login;

        /// <summary>
        /// Gets or sets the Login.
        /// </summary>
        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        /// <summary>
        /// Defines the email.
        /// </summary>
        private string email;

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        /// <summary>
        /// Defines the password.
        /// </summary>
        private string password;

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        /// <summary>
        /// Defines the role.
        /// </summary>
        public Role role;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="login">The login<see cref="string"/>.</param>
        /// <param name="password">The password<see cref="string"/>.</param>
        /// <param name="email">The email<see cref="string"/>.</param>
        public User(string login, string password, string email)
        {
            this.login = login;
            this.password = password;
            this.email = email;
        }
    }
}

/// <summary>
/// Defines the Role.
/// </summary>
enum Role
{
    /// <summary>
    /// Defines the Admin.
    /// </summary>
    Admin,

    /// <summary>
    /// Defines the User.
    /// </summary>
    User,

    /// <summary>
    /// Defines the Trainer.
    /// </summary>
    Trainer
}
