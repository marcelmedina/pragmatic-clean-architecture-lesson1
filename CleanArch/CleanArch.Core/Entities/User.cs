using CleanArch.Core.Enums;

namespace CleanArch.Core.Entities
{
    public class User
    {
        public User(string name, string email)
        {
            Name = name;
            Email = email;
            DateCreated = DateTime.UtcNow;
            Status = UserStatusEnum.JustJoined;
            Comments = new List<Comment>();
            Likes = new List<Like>();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime DateCreated { get; private set; }
        public UserStatusEnum Status { get; private set; }
        public List<Comment> Comments { get; private set; }
        public List<Like> Likes { get; private set; }

        public void AssignNotThereYet()
        {
            if (Status == UserStatusEnum.JustJoined)
            {
                Status = UserStatusEnum.NotReadyYet;
            }
        }

        public void Enable()
        {
            if (Status == UserStatusEnum.NotReadyYet)
            {
                Status = UserStatusEnum.Enabled;
            }
        }

        public void Disable()
        {
            if (Status == UserStatusEnum.Enabled || Status == UserStatusEnum.Warning)
            {
                Status = UserStatusEnum.Disabled;
            }
        }

        public void Warning()
        {
            if (Status == UserStatusEnum.Enabled)
            {
                Status = UserStatusEnum.Warning;
            }
        }

        public void Ban()
        {
            if (Status == UserStatusEnum.Warning)
            {
                Status = UserStatusEnum.Banned;
            }

            Warning();
        }

    }
}
