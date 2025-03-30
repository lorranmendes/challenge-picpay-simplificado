namespace PicPaySimplificado.Tests.Fixtures
{
    public class UserFixture
    {
        private readonly Faker faker;
        private readonly Fixture fixture;
        public UserFixture()
        {
            this.faker = new Faker();
            this.fixture = new Fixture();
        }

        public User GetUser()
        {
            var userType = fixture.Create<UserTypeEnum>();
            var email = faker.Internet.Email();
            return new User
            {
                Name = faker.Person.FullName,
                Email = new Email(email),
                Password = faker.Internet.Password(),
                Type = userType,
                Document = userType == UserTypeEnum.Common
                ? faker.Person.Cpf()
                    : faker.Company.Cnpj()
            };
        }
    }
}
