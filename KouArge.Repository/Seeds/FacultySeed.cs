//using KouArge.Core.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace KouArge.Repository.Seeds
//{
//    public class FacultySeed : IEntityTypeConfiguration<Faculty>
//    {
//        public void Configure(EntityTypeBuilder<Faculty> builder)
//        {
//            builder.HasData(new Faculty()
//            {
//                Id = 1,
//                Name = "Ali Rıza Veziroğlu Meslek Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 2,
//                Name = "Asım Kocabıyık Meslek Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 3,
//                Name = "Değirmendere Ali ÖZBAY Meslek Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 4,
//                Name = "Teknoloji",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 5,
//                Name = "Denizcilik Fakültesi",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 6,
//                Name = "Diş Hekimliği Fakültesi",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 7,
//                Name = "Diş Hekimliği Fakültesi",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 8,
//                Name = "Eğitim Fakültesi",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 9,
//                Name = "Fen - Edebiyat Fakültesi",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 10,
//                Name = "Ford Otosan İhsaniye Otomotiv Meslek Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 11,
//                Name = "Gazanfer Bilge Meslek Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 12,
//                Name = "Gıda ve Tarım Meslek Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,

//            },
//            new Faculty()
//            {
//                Id = 13,
//                Name = "Gölcük Meslek Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,

//            },
//            new Faculty()
//            {
//                Id = 14,
//                Name = "Güzel Sanatlar Fakültesi",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,

//            },
//            new Faculty()
//            {
//                Id = 15,
//                Name = "Havacılık ve Uzay Bilimleri Fakültesi",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,

//            },
//            new Faculty()
//            {
//                Id = 16,
//                Name = "Hereke Asım Kocabıyık Meslek Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,

//            },
//            new Faculty()
//            {
//                Id = 17,
//                Name = "Hereke Meslek Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 18,
//                Name = "Hereke Ömer İsmet Uzunyol Meslek Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 19,
//                Name = "Hukuk Fakültesi",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 20,
//                Name = "İktisadi ve İdari Bilimler Fakültesi",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 21,
//                Name = "İlahiyat Fakültesi",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 22,
//                Name = "İletişim Fakültesi",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 23,
//                Name = "İzmit Meslek Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 24,
//                Name = "Kandıra Meslek Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 25,
//                Name = "Karamürsel Meslek Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 26,
//                Name = "Kartepe Atçılık Meslek Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 27,
//                Name = "Kartepe Turizm Meslek Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 28,
//                Name = "Kocaeli Meslek Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 29,
//                Name = "Kocaeli Sağlık Hizmetleri Meslek Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 30,
//                Name = "Koseköy Meslek Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 31,
//                Name = "Mimarlık ve Tasarım Fakültesi",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 32,
//                Name = "Mühendislik Fakültesi",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 33,
//                Name = "Sağlık Bilimleri Fakültesi",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 34,
//                Name = "Spor Bilimleri Fakültesi",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 35,
//                Name = "Teknoloji Fakültesi",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 36,
//                Name = "Tıp Fakültesi",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 37,
//                Name = "Turizm Fakültesi",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 38,
//                Name = "Turizm İşletmecliliği ve Otelcilik Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 39,
//                Name = "Uzunçiftlik Nuh Çimento Meslek Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 40,
//                Name = "Yahya Kaptan Meslek Yüksekokulu",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            },
//            new Faculty()
//            {
//                Id = 41,
//                Name = "Ziraat Fakültesi",
//                Campus = "Kocaeli",
//                CreatedAt = DateTime.Now,
//            }
//            );


//        }
//    }
//}
