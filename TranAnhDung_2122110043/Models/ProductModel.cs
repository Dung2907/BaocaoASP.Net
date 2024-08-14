using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TranAnhDung_2122110043.Context;

namespace TranAnhDung_2122110043.Models
{
    public class ProductModel
    {
        public List<Brand> ListBrand { get; set; }
        public List<Category> ListCategory { get; set; }
        public long id { get; set; }

        [Required(ErrorMessage = "Danh mục là bắt buộc")]
        [Display(Name = "Danh mục")]
        public long category_id { get; set; }

        [Required(ErrorMessage = "Thương hiệu là bắt buộc")]
        [Display(Name = "Thương hiệu")]
        public long brand_id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
        [StringLength(255, ErrorMessage = "Tên sản phẩm không được vượt quá 255 ký tự")]
        [Display(Name = "Tên sản phẩm")]
        public string name { get; set; }

        [Display(Name = "Slug")]
        public string slug { get; set; }

        [Display(Name = "Mô tả")]
        public string description { get; set; }

        [Display(Name = "Thông số kỹ thuật")]
        public string specs { get; set; }

        [Display(Name = "Hình ảnh")]
        public string image { get; set; }

        [Required(ErrorMessage = "Giá là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá phải là số dương")]
        [Display(Name = "Giá")]
        public decimal price { get; set; }

        [Display(Name = "Giá khuyến mãi")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá khuyến mãi phải là số dương")]
        public decimal? sale_price { get; set; }

        [Required(ErrorMessage = "Số lượng tồn kho là bắt buộc")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng tồn kho phải là số nguyên dương")]
        [Display(Name = "Số lượng tồn kho")]
        public int stock { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? created_at { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime? updated_at { get; set; }

        [Required(ErrorMessage = "Trạng thái là bắt buộc")]
        [Range(0, 1, ErrorMessage = "Trạng thái phải là 0 hoặc 1")]
        [Display(Name = "Trạng thái")]
        public byte status { get; set; }
    }
}