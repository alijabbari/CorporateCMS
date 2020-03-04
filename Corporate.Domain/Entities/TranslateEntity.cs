using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Domain.Entities
{
    public class TranslateEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// نامی  که نشان میدهد موجودیت چیست مثال : اخبار یا محصول یا دسته و ...
        /// </summary>
        public string EntityIdentify { get; set; }
        /// <summary>
        /// شناسه موجودیت که با جدول اصلی رابطه دارد مثلا محصول با شناسه ۱
        /// </summary>
        public int EntityId { get; set; }
        /// <summary>
        /// مشخصات مربوط به کدام زبان است 
        /// </summary>
        public int LanguageId { get; set; }
        /// <summary>
        /// کدام ویژگی از موجودیت است  مثال : Product.Name ,Product.ShortDescription
        /// </summary>
        public string TranslateKey{ get; set; }
        /// <summary>
        /// مقدار ویژگی  :Product.name=sumsung Galaxy S20
        /// </summary>
        public string TranslateValue { get; set; }
    }
}
