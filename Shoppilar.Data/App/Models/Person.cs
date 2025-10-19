using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppilar.Data.App.Models;

[Table("persons")]
public class Person : EntityBase
{
    #region Properties

    [Column("name")] public required string Name { get; set; }
    [Column("birth")] public required DateTime Birth { get; set; }

    #endregion

    #region Foreign keys

    [Column("person_type_id")] public required Guid PersonTypeId { get; set; }
    [Column("image_id")] public Guid? ImageId { get; set; }

    #endregion

    #region Navigation properties

    public PersonType? PersonType { get; set; }

    public Image? Image { get; set; }

    #endregion

    #region Collections

    public ICollection<PersonAddress> Addresses { get; set; } = new List<PersonAddress>();
    public ICollection<PersonDocument> Documents { get; set; } = new List<PersonDocument>();
    public ICollection<PersonContact> Contacts { get; set; } = new List<PersonContact>();
    public ICollection<PersonSocialMedia> SocialMedias { get; set; } = new List<PersonSocialMedia>();
    public ICollection<PersonFollower> Followers { get; set; } = new List<PersonFollower>(); // Quem segue este usuário
    public ICollection<PersonFollower> Following { get; set; } = new List<PersonFollower>(); // Quem este usuário segue

    #endregion
}

[Table("person_addresses")]
public class PersonAddress : EntityBase
{
    #region Properties

    [Column("street")] public required string Street { get; set; }
    [Column("neighborhood")] public required string Neighborhood { get; set; }
    [Column("number")] public required string Number { get; set; }
    [Column("complement")] public string? Complement { get; set; }
    [Column("zip_code")] public required string ZipCode { get; set; }
    [Column("standard")] public bool Standard { get; set; }

    #endregion

    #region Foreign keys

    [Column("person_id")] public required Guid PersonId { get; set; }
    [Column("city_id")] public required Guid CityId { get; set; }

    #endregion

    #region Navigation properties

    public City? City { get; set; }
    public Person? Person { get; set; }

    #endregion
}

[Table("person_documents")]
public class PersonDocument : EntityBase
{
    #region Properties

    [Column("document_number")] public required string DocumentNumber { get; set; }
    [Column("validate")] public DateTime? Validate { get; set; }
    [Column("standard")] public bool Standard { get; set; }

    #endregion

    #region Foreign keys

    [Column("category_type_id")] public Guid? CategoryTypeId { get; set; } // A,B,C etc.
    [Column("person_id")] public required Guid PersonId { get; set; }
    [Column("document_type_id")] public required Guid DocumentTypeId { get; set; } // CPF, CNPJ, Passaporte etc.

    #endregion

    #region Navigation properties

    public DocumentType? DocumentType { get; set; }
    public CategoryType? CategoryType { get; set; }
    public Person? Person { get; set; }

    #endregion
}

[Table("person_contacts")]
public class PersonContact : EntityBase
{
    #region Properties

    [Column("contact_value")] public required string ContactValue { get; set; }
    [Column("standard")] public bool Standard { get; set; }

    #endregion

    #region Foreign keys

    [Column("person_id")] public required Guid PersonId { get; set; }
    [Column("contact_type_id")] public required Guid ContactTypeId { get; set; }

    #endregion

    #region Navigation properties

    public ContactType? ContactType { get; set; }
    public Person? Person { get; set; }

    #endregion
}

[Table("person_followers")]
public class PersonFollower : EntityBase
{
    #region Foreign keys

    [Column("follower_id")] public required Guid FollowerId { get; set; } // Quem segue
    [Column("followed_id")] public required Guid FollowedId { get; set; } // Quem é seguido

    #endregion

    #region Navigation properties

    public Person? Follower { get; set; }
    public Person? Followed { get; set; }

    #endregion
}

[Table("person_social_medias")]
public class PersonSocialMedia : EntityBase
{
    #region Properties

    [Column("profile_url")] public required string ProfileUrl { get; set; }

    #endregion

    #region Foreign keys

    [Column("person_id")] public required Guid PersonId { get; set; }
    [Column("social_media_type_id")] public required Guid SocialMediaTypeId { get; set; }

    #endregion

    #region Navigation properties

    public Person? Person { get; set; }
    public SocialMediaType? SocialMediaType { get; set; }

    #endregion
}

[Table("person_search_histories")]
public class PersonSearchHistory : EntityBase
{
    #region Properties

    [Column("query")] public required string Query { get; set; }
    [Column("searched_at")] public required DateTime SearchedAt { get; set; }

    #endregion

    #region Foreign keys

    [Column("person_id")] public required Guid PersonId { get; set; }

    #endregion

    #region Navigation properties

    public Person? Person { get; set; }

    #endregion
}