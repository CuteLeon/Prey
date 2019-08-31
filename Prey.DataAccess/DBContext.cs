using Microsoft.EntityFrameworkCore;
using Prey.Models;

namespace Prey.DataAccess
{
    /// <summary>
    /// 数据库交互
    /// </summary>
    public class DBContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DBContext"/> class.
        /// </summary>
        /// <param name="options"></param>
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        #region 人员

        /// <summary>
        /// Gets or sets 人员
        /// </summary>
        public DbSet<Person> Persons { get; set; }
        #endregion

        #region 设备

        /// <summary>
        /// Gets or sets 桌面电脑
        /// </summary>
        public DbSet<DesktopComputer> DesktopComputers { get; set; }

        /// <summary>
        /// Gets or sets 笔记本电脑
        /// </summary>
        public DbSet<LaptopComputer> LaptopComputers { get; set; }

        /// <summary>
        /// Gets or sets 手机
        /// </summary>
        public DbSet<Phone> Phones { get; set; }
        #endregion

        #region 设备附加信息

        /// <summary>
        /// Gets or sets 联系人
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// Gets or sets 位置
        /// </summary>
        public DbSet<Location> Locations { get; set; }

        /// <summary>
        /// Gets or sets 上传文件
        /// </summary>
        public DbSet<UploadFile> UploadFiles { get; set; }
        #endregion

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// 创建模型
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 外键

            modelBuilder.Entity<DesktopComputer>().HasOne(device => device.Owner).WithMany(person => person.DesktopComputers).HasForeignKey(device => device.OwnerID).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<LaptopComputer>().HasOne(device => device.Owner).WithMany(person => person.LaptopComputers).HasForeignKey(device => device.OwnerID).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Phone>().HasOne(device => device.Owner).WithMany(person => person.Phones).HasForeignKey(device => device.OwnerID).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Location>().HasOne(attach => attach.Device).WithMany(device => device.Locations).HasForeignKey(attach => attach.DeviceID).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Contact>().HasOne(attach => attach.Device).WithMany(device => device.Contacts).HasForeignKey(attach => attach.DeviceID).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UploadFile>().HasOne(attach => attach.Device).WithMany(device => device.UploadFiles).HasForeignKey(attach => attach.DeviceID).OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region 索引

            modelBuilder.Entity<Person>().HasIndex(person => new { person.ID }).HasName($"{nameof(Person)}_Index").IsUnique();

            modelBuilder.Entity<DesktopComputer>().HasIndex(device => new { device.OwnerID, device.ID }).HasName($"{nameof(DesktopComputer)}_Index").IsUnique();
            modelBuilder.Entity<LaptopComputer>().HasIndex(device => new { device.OwnerID, device.ID }).HasName($"{nameof(LaptopComputer)}_Index").IsUnique();
            modelBuilder.Entity<Phone>().HasIndex(device => new { device.OwnerID, device.ID }).HasName($"{nameof(Phone)}_Index").IsUnique();

            modelBuilder.Entity<Location>().HasIndex(attach => new { attach.DeviceID, attach.CreateTime, attach.ID }).HasName($"{nameof(Location)}_Index").IsUnique();
            modelBuilder.Entity<Contact>().HasIndex(attach => new { attach.DeviceID, attach.CreateTime, attach.ID }).HasName($"{nameof(Contact)}_Index").IsUnique();
            modelBuilder.Entity<UploadFile>().HasIndex(attach => new { attach.DeviceID, attach.CreateTime, attach.ID }).HasName($"{nameof(UploadFile)}_Index").IsUnique();
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
