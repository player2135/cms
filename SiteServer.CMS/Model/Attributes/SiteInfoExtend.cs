﻿using System;
using SiteServer.Utils;
using SiteServer.Utils.Enumerations;

namespace SiteServer.CMS.Model.Attributes
{
    [Serializable]
    public class SiteInfoExtend : ExtendedAttributes
    {
        private readonly string _siteDir;

        public SiteInfoExtend(string siteDir, string settingsXml)
        {
            _siteDir = siteDir;
            Load(settingsXml);
        }

        /****************站点设置********************/

        public string Charset
        {
            get => GetString(nameof(Charset), ECharsetUtils.GetValue(ECharset.utf_8));
            set => Set(nameof(Charset), value);
        }

        public int PageSize
        {
            get => GetInt(nameof(PageSize), 30);
            set => Set(nameof(PageSize), value.ToString());
        }

        public bool IsCheckContentLevel
        {
            get => GetBool(nameof(IsCheckContentLevel));
            set => Set(nameof(IsCheckContentLevel), value.ToString());
        }

        public int CheckContentLevel {
            get => IsCheckContentLevel ? GetInt(nameof(CheckContentLevel)) : 1;
            set => Set(nameof(CheckContentLevel), value.ToString());
        }

        public bool IsSaveImageInTextEditor
        {
            get => GetBool(nameof(IsSaveImageInTextEditor), true);
            set => Set(nameof(IsSaveImageInTextEditor), value.ToString());
        }

        public bool IsAutoPageInTextEditor
        {
            get => GetBool(nameof(IsAutoPageInTextEditor));
            set => Set(nameof(IsAutoPageInTextEditor), value.ToString());
        }

        public int AutoPageWordNum
        {
            get => GetInt(nameof(AutoPageWordNum), 1500);
            set => Set(nameof(AutoPageWordNum), value.ToString());
        }

        public bool IsContentTitleBreakLine
        {
            get => GetBool(nameof(IsContentTitleBreakLine));
            set => Set(nameof(IsContentTitleBreakLine), value.ToString());
        }

        public bool IsAutoCheckKeywords
        {
            get => GetBool(nameof(IsAutoCheckKeywords));
            set => Set(nameof(IsAutoCheckKeywords), value.ToString());
        }

        public int PhotoSmallWidth
        {
            get => GetInt(nameof(PhotoSmallWidth), 70);
            set => Set(nameof(PhotoSmallWidth), value.ToString());
        }

        public int PhotoMiddleWidth
        {
            get => GetInt(nameof(PhotoMiddleWidth), 400);
            set => Set(nameof(PhotoMiddleWidth), value.ToString());
        }

        /****************图片水印设置********************/

        public bool IsWaterMark
        {
            get => GetBool(nameof(IsWaterMark));
            set => Set(nameof(IsWaterMark), value.ToString());
        }

        public bool IsImageWaterMark
        {
            get => GetBool(nameof(IsImageWaterMark));
            set => Set(nameof(IsImageWaterMark), value.ToString());
        }

        public int WaterMarkPosition
        {
            get => GetInt(nameof(WaterMarkPosition), 9);
            set => Set(nameof(WaterMarkPosition), value.ToString());
        }

        public int WaterMarkTransparency
        {
            get => GetInt(nameof(WaterMarkTransparency), 5);
            set => Set(nameof(WaterMarkTransparency), value.ToString());
        }

        public int WaterMarkMinWidth
        {
            get => GetInt(nameof(WaterMarkMinWidth), 200);
            set => Set(nameof(WaterMarkMinWidth), value.ToString());
        }

        public int WaterMarkMinHeight
        {
            get => GetInt(nameof(WaterMarkMinHeight), 200);
            set => Set(nameof(WaterMarkMinHeight), value.ToString());
        }

        public string WaterMarkFormatString
        {
            get => GetString(nameof(WaterMarkFormatString), string.Empty);
            set => Set(nameof(WaterMarkFormatString), value);
        }

        public string WaterMarkFontName
        {
            get => GetString(nameof(WaterMarkFontName), string.Empty);
            set => Set(nameof(WaterMarkFontName), value);
        }

        public int WaterMarkFontSize
        {
            get => GetInt(nameof(WaterMarkFontSize), 12);
            set => Set(nameof(WaterMarkFontSize), value.ToString());
        }

        public string WaterMarkImagePath
        {
            get => GetString(nameof(WaterMarkImagePath), string.Empty);
            set => Set(nameof(WaterMarkImagePath), value);
        }

        /****************生成页面设置********************/

        public bool IsSeparatedWeb
        {
            get => GetBool(nameof(IsSeparatedWeb));
            set => Set(nameof(IsSeparatedWeb), value.ToString());
        }

        public string SeparatedWebUrl
        {
            get => GetString(nameof(SeparatedWebUrl));
            set => Set(nameof(SeparatedWebUrl), value);
        }

        public string WebUrl => IsSeparatedWeb ? SeparatedWebUrl : PageUtils.ParseNavigationUrl($"~/{_siteDir}");

        public bool IsSeparatedAssets
        {
            get => GetBool(nameof(IsSeparatedAssets));
            set => Set(nameof(IsSeparatedAssets), value.ToString());
        }

        public string SeparatedAssetsUrl
        {
            get => GetString(nameof(SeparatedAssetsUrl));
            set => Set(nameof(SeparatedAssetsUrl), value);
        }

        public string AssetsDir
        {
            get => GetString(nameof(AssetsDir), "upload");
            set => Set(nameof(AssetsDir), value);
        }

        public string AssetsUrl => IsSeparatedAssets ? SeparatedAssetsUrl : PageUtils.ParseNavigationUrl($"~/{_siteDir}/{AssetsDir}/");

        public string ChannelFilePathRule
        {
            get => GetString(nameof(ChannelFilePathRule), "/channels/{@ChannelID}.html");
            set => Set(nameof(ChannelFilePathRule), value);
        }

        public string ContentFilePathRule
        {
            get => GetString(nameof(ContentFilePathRule), "/contents/{@ChannelID}/{@ContentID}.html");
            set => Set(nameof(ContentFilePathRule), value);
        }

        public bool IsCreateContentIfContentChanged
        {
            get => GetBool(nameof(IsCreateContentIfContentChanged), true);
            set => Set(nameof(IsCreateContentIfContentChanged), value.ToString());
        }

        public bool IsCreateChannelIfChannelChanged
        {
            get => GetBool(nameof(IsCreateChannelIfChannelChanged), true);
            set => Set(nameof(IsCreateChannelIfChannelChanged), value.ToString());
        }

        public bool IsCreateShowPageInfo
        {
            get => GetBool(nameof(IsCreateShowPageInfo));
            set => Set(nameof(IsCreateShowPageInfo), value.ToString());
        }

        public bool IsCreateIe8Compatible
        {
            get => GetBool(nameof(IsCreateIe8Compatible));
            set => Set(nameof(IsCreateIe8Compatible), value.ToString());
        }

        public bool IsCreateBrowserNoCache
        {
            get => GetBool(nameof(IsCreateBrowserNoCache));
            set => Set(nameof(IsCreateBrowserNoCache), value.ToString());
        }

        public bool IsCreateJsIgnoreError
        {
            get => GetBool(nameof(IsCreateJsIgnoreError));
            set => Set(nameof(IsCreateJsIgnoreError), value.ToString());
        }

        public bool IsCreateWithJQuery
        {
            get => GetBool(nameof(IsCreateWithJQuery));
            set => Set(nameof(IsCreateWithJQuery), value.ToString());
        }

        public bool IsCreateDoubleClick
        {
            get => GetBool(nameof(IsCreateDoubleClick));
            set => Set(nameof(IsCreateDoubleClick), value.ToString());
        }

        public int CreateStaticMaxPage
        {
            get => GetInt(nameof(CreateStaticMaxPage), 10);
            set => Set(nameof(CreateStaticMaxPage), value.ToString());
        }

        public bool IsCreateUseDefaultFileName
        {
            get => GetBool(nameof(IsCreateUseDefaultFileName));
            set => Set(nameof(IsCreateUseDefaultFileName), value.ToString());
        }

        public string CreateDefaultFileName
        {
            get => GetString(nameof(CreateDefaultFileName), "index.html");
            set => Set(nameof(CreateDefaultFileName), value);
        }

        public bool IsCreateStaticContentByAddDate
        {
            get => GetBool(nameof(IsCreateStaticContentByAddDate));
            set => Set(nameof(IsCreateStaticContentByAddDate), value.ToString());
        }

        public DateTime CreateStaticContentAddDate
        {
            get => GetDateTime(nameof(CreateStaticContentAddDate), DateTime.MinValue);
            set => Set(nameof(CreateStaticContentAddDate), DateUtils.GetDateString(value));
        }

        /****************跨站转发设置********************/

        public bool IsCrossSiteTransChecked
        {
            get => GetBool(nameof(IsCrossSiteTransChecked));
            set => Set(nameof(IsCrossSiteTransChecked), value.ToString());
        }

        /****************记录系统操作设置********************/

        public bool ConfigTemplateIsCodeMirror
        {
            get => GetBool(nameof(ConfigTemplateIsCodeMirror), true);
            set => Set(nameof(ConfigTemplateIsCodeMirror), value.ToString());
        }

        public int ConfigVideoContentInsertWidth
        {
            get => GetInt(nameof(ConfigVideoContentInsertWidth), 420);
            set => Set(nameof(ConfigVideoContentInsertWidth), value.ToString());
        }

        public int ConfigVideoContentInsertHeight
        {
            get => GetInt(nameof(ConfigVideoContentInsertHeight), 280);
            set => Set(nameof(ConfigVideoContentInsertHeight), value.ToString());
        }

        public string ConfigExportType
        {
            get => GetString(nameof(ConfigExportType), string.Empty);
            set => Set(nameof(ConfigExportType), value);
        }

        public string ConfigExportPeriods
        {
            get => GetString(nameof(ConfigExportPeriods), string.Empty);
            set => Set(nameof(ConfigExportPeriods), value);
        }

        public string ConfigExportDisplayAttributes
        {
            get => GetString(nameof(ConfigExportDisplayAttributes), string.Empty);
            set => Set(nameof(ConfigExportDisplayAttributes), value);
        }

        public string ConfigExportIsChecked
        {
            get => GetString(nameof(ConfigExportIsChecked), string.Empty);
            set => Set(nameof(ConfigExportIsChecked), value);
        }

        public string ConfigSelectImageCurrentUrl
        {
            get => GetString(nameof(ConfigSelectImageCurrentUrl), "@/" + ImageUploadDirectoryName);
            set => Set(nameof(ConfigSelectImageCurrentUrl), value);
        }

        public string ConfigSelectVideoCurrentUrl
        {
            get => GetString(nameof(ConfigSelectVideoCurrentUrl), "@/" + VideoUploadDirectoryName);
            set => Set(nameof(ConfigSelectVideoCurrentUrl), value);
        }

        public string ConfigSelectFileCurrentUrl
        {
            get => GetString(nameof(ConfigSelectFileCurrentUrl), "@/" + FileUploadDirectoryName);
            set => Set(nameof(ConfigSelectFileCurrentUrl), value);
        }

        public string ConfigUploadImageIsTitleImage
        {
            get => GetString(nameof(ConfigUploadImageIsTitleImage), "True");
            set => Set(nameof(ConfigUploadImageIsTitleImage), value);
        }

        public string ConfigUploadImageTitleImageWidth
        {
            get => GetString(nameof(ConfigUploadImageTitleImageWidth), "300");
            set => Set(nameof(ConfigUploadImageTitleImageWidth), value);
        }

        public string ConfigUploadImageTitleImageHeight
        {
            get => GetString(nameof(ConfigUploadImageTitleImageHeight), string.Empty);
            set => Set(nameof(ConfigUploadImageTitleImageHeight), value);
        }

        public string ConfigUploadImageIsShowImageInTextEditor
        {
            get => GetString(nameof(ConfigUploadImageIsShowImageInTextEditor), "True");
            set => Set(nameof(ConfigUploadImageIsShowImageInTextEditor), value);
        }

        public string ConfigUploadImageIsLinkToOriginal
        {
            get => GetString(nameof(ConfigUploadImageIsLinkToOriginal), string.Empty);
            set => Set(nameof(ConfigUploadImageIsLinkToOriginal), value);
        }

        public string ConfigUploadImageIsSmallImage
        {
            get => GetString(nameof(ConfigUploadImageIsSmallImage), "True");
            set => Set(nameof(ConfigUploadImageIsSmallImage), value);
        }

        public string ConfigUploadImageSmallImageWidth
        {
            get => GetString(nameof(ConfigUploadImageSmallImageWidth), "500");
            set => Set(nameof(ConfigUploadImageSmallImageWidth), value);
        }

        public string ConfigUploadImageSmallImageHeight
        {
            get => GetString(nameof(ConfigUploadImageSmallImageHeight), string.Empty);
            set => Set(nameof(ConfigUploadImageSmallImageHeight), value);
        }

        /****************上传设置*************************/

        public string ImageUploadDirectoryName
        {
            get => GetString(nameof(ImageUploadDirectoryName), "upload/images");
            set => Set(nameof(ImageUploadDirectoryName), value);
        }

        public string ImageUploadDateFormatString
        {
            get => GetString(nameof(ImageUploadDateFormatString), EDateFormatTypeUtils.GetValue(EDateFormatType.Month));
            set => Set(nameof(ImageUploadDateFormatString), value);
        }

        public bool IsImageUploadChangeFileName
        {
            get => GetBool(nameof(IsImageUploadChangeFileName), true);
            set => Set(nameof(IsImageUploadChangeFileName), value.ToString());
        }

        public string ImageUploadTypeCollection
        {
            get => GetString(nameof(ImageUploadTypeCollection), "gif|jpg|jpeg|bmp|png|pneg|swf");
            set => Set(nameof(ImageUploadTypeCollection), value);
        }

        public int ImageUploadTypeMaxSize
        {
            get => GetInt(nameof(ImageUploadTypeMaxSize), 15360);
            set => Set(nameof(ImageUploadTypeMaxSize), value.ToString());
        }

        public string VideoUploadDirectoryName
        {
            get => GetString(nameof(VideoUploadDirectoryName), "upload/videos");
            set => Set(nameof(VideoUploadDirectoryName), value);
        }

        public string VideoUploadDateFormatString
        {
            get => GetString(nameof(VideoUploadDateFormatString), EDateFormatTypeUtils.GetValue(EDateFormatType.Month));
            set => Set(nameof(VideoUploadDateFormatString), value);
        }

        public bool IsVideoUploadChangeFileName
        {
            get => GetBool(nameof(IsVideoUploadChangeFileName), true);
            set => Set(nameof(IsVideoUploadChangeFileName), value.ToString());
        }

        public string VideoUploadTypeCollection
        {
            get => GetString(nameof(VideoUploadTypeCollection), "asf|asx|avi|flv|mid|midi|mov|mp3|mp4|mpg|mpeg|ogg|ra|rm|rmb|rmvb|rp|rt|smi|swf|wav|webm|wma|wmv|viv");
            set => Set(nameof(VideoUploadTypeCollection), value);
        }

        public int VideoUploadTypeMaxSize
        {
            get => GetInt(nameof(VideoUploadTypeMaxSize), 307200);
            set => Set(nameof(VideoUploadTypeMaxSize), value.ToString());
        }

        public string FileUploadDirectoryName
        {
            get => GetString(nameof(FileUploadDirectoryName), "upload/files");
            set => Set(nameof(FileUploadDirectoryName), value);
        }

        public string FileUploadDateFormatString
        {
            get => GetString(nameof(FileUploadDateFormatString), EDateFormatTypeUtils.GetValue(EDateFormatType.Month));
            set => Set(nameof(FileUploadDateFormatString), value);
        }

        public bool IsFileUploadChangeFileName
        {
            get => GetBool(nameof(IsFileUploadChangeFileName), true);
            set => Set(nameof(IsFileUploadChangeFileName), value.ToString());
        }

        public string FileUploadTypeCollection
        {
            get => GetString(nameof(FileUploadTypeCollection), "zip,rar,7z,js,css,txt,doc,docx,ppt,pptx,xls,xlsx,pdf");
            set => Set(nameof(FileUploadTypeCollection), value);
        }

        public int FileUploadTypeMaxSize
        {
            get => GetInt(nameof(FileUploadTypeMaxSize), 307200);
            set => Set(nameof(FileUploadTypeMaxSize), value.ToString());
        }
    }
}
