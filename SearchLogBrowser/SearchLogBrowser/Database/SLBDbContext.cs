namespace SearchLogBrowser.Database
{
    using Microsoft.Extensions.Logging;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SLBDbContext : DbContext
    {
        // コンテキストは、アプリケーションの構成ファイル (App.config または Web.config) から 'Model1' 
        // 接続文字列を使用するように構成されています。既定では、この接続文字列は LocalDb インスタンス上
        // の 'SearchLogBrowser.Database.SLBDbContext' データベースを対象としています。 
        // 
        // 別のデータベースとデータベース プロバイダーまたはそのいずれかを対象とする場合は、
        // アプリケーション構成ファイルで 'Model1' 接続文字列を変更してください。
        public SLBDbContext() : base(nameOrConnectionString: "Default") {}

        // モデルに含めるエンティティ型ごとに DbSet を追加します。Code First モデルの構成および使用の
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=390109 を参照してください。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        //public virtual DbSet<Searchword> Searchwords { get; set; }
        public virtual DbSet<Searchlog> Searchlogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<Searchlog>().HasKey(c => new { c.Logno });

            base.OnModelCreating(modelBuilder);
        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}