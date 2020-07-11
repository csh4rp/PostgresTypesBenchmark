using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresTypesBenchmark
{
    [Table("table_guid")]
    public class TestGuid
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("value")]
        public decimal Value { get; set; }
    }
    
    [Table("table_guid_default")]
    public class TestGuidDefault
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("value")]
        public decimal Value { get; set; }
    }
    
    [Table("table_int")]
    public class TestInt
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("value")]
        public decimal Value { get; set; }
    }
    
    [Table("table_long")]
    public class TestLong
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("value")]
        public decimal Value { get; set; }
    }
}