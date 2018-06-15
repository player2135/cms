﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using SiteServer.CMS.Api;
using SiteServer.CMS.Core;
using SiteServer.CMS.Model;
using SiteServer.CMS.Plugin;
using SiteServer.Utils;

namespace SiteServer.API.Controllers.Sys.Settings.Admin
{
    [RoutePrefix("api")]
    public class AccessTokensController : ApiController
    {
        private const string ApiRoute = "sys/settings/admin/accessTokens";
        private const string ApiRouteGetAdminNames = "sys/settings/admin/accessTokens/action/getAdminNames";
        private const string ApiRouteGetAccessToken = "sys/settings/admin/accessTokens/action/getAccessToken/{id:int}";
        private const string ApiRouteRegenerate = "sys/settings/admin/accessTokens/action/regenerate/{id:int}";

        [HttpGet, Route(ApiRoute)]
        public IHttpActionResult GetItems()
        {
            try
            {
                var request = new AuthRequest();
                if (!request.IsAdminLoggin ||
                    !request.AdminPermissions.HasAdministratorPermissions(ConfigManager.SettingsPermissions.Admin))
                {
                    return Unauthorized();
                }

                return Ok(new
                {
                    Value = DataProvider.AccessTokenDao.GetAccessTokenInfoList(),
                    AdminName = request.AdminName
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route(ApiRouteGetAdminNames)]
        public IHttpActionResult GetAdminNames()
        {
            try
            {
                var request = new AuthRequest();
                if (!request.IsAdminLoggin ||
                    !request.AdminPermissions.HasAdministratorPermissions(ConfigManager.SettingsPermissions.Admin))
                {
                    return Unauthorized();
                }

                var userNameList = new List<string>();

                if (request.AdminPermissions.IsConsoleAdministrator)
                {
                    userNameList = DataProvider.AdministratorDao.GetUserNameList();
                }
                else
                {
                    userNameList.Add(request.AdminName);
                }

                return Ok(new
                {
                    Value = userNameList
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet, Route(ApiRouteGetAccessToken)]
        public IHttpActionResult GetAccessToken(int id)
        {
            try
            {
                var request = new AuthRequest();
                if (!request.IsAdminLoggin ||
                    !request.AdminPermissions.HasAdministratorPermissions(ConfigManager.SettingsPermissions.Admin))
                {
                    return Unauthorized();
                }

                var tokenInfo = DataProvider.AccessTokenDao.GetAccessTokenInfo(id);
                var accessToken = TranslateUtils.DecryptStringBySecretKey(tokenInfo.Token);

                return Ok(new
                {
                    Value = accessToken
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete, Route(ApiRoute)]
        public IHttpActionResult Delete([FromBody] IdObj delObj)
        {
            try
            {
                var request = new AuthRequest();
                if (!request.IsAdminLoggin ||
                    !request.AdminPermissions.HasAdministratorPermissions(ConfigManager.SettingsPermissions.Admin))
                {
                    return Unauthorized();
                }

                DataProvider.AccessTokenDao.Delete(delObj.Id);

                return Ok(new
                {
                    Value = DataProvider.AccessTokenDao.GetAccessTokenInfoList()
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost, Route(ApiRoute)]
        public IHttpActionResult Submit([FromBody] AccessTokenInfo itemObj)
        {
            try
            {
                var request = new AuthRequest();
                if (!request.IsAdminLoggin ||
                    !request.AdminPermissions.HasAdministratorPermissions(ConfigManager.SettingsPermissions.Admin))
                {
                    return Unauthorized();
                }

                if (itemObj.Id > 0)
                {
                    var tokenInfo = DataProvider.AccessTokenDao.GetAccessTokenInfo(itemObj.Id);

                    if (tokenInfo.Title != itemObj.Title && DataProvider.AccessTokenDao.IsTitleExists(itemObj.Title))
                    {
                        return BadRequest("保存失败，已存在相同标题的API密钥！");
                    }

                    tokenInfo.Title = itemObj.Title;
                    tokenInfo.AdminName = itemObj.AdminName;
                    tokenInfo.Scopes = itemObj.Scopes;

                    DataProvider.AccessTokenDao.Update(tokenInfo);

                    request.AddAdminLog("修改API密钥", $"Access Token:{tokenInfo.Title}");
                }
                else
                {
                    if (DataProvider.AccessTokenDao.IsTitleExists(itemObj.Title))
                    {
                        return BadRequest("保存失败，已存在相同标题的API密钥！");
                    }

                    var tokenInfo = new AccessTokenInfo
                    {
                        Title = itemObj.Title,
                        AdminName = itemObj.AdminName,
                        Scopes = itemObj.Scopes
                    };

                    DataProvider.AccessTokenDao.Insert(tokenInfo);

                    request.AddAdminLog("新增API密钥", $"Access Token:{tokenInfo.Title}");
                }

                return Ok(new
                {
                    Value = DataProvider.AccessTokenDao.GetAccessTokenInfoList()
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost, Route(ApiRouteRegenerate)]
        public IHttpActionResult Regenerate(int id)
        {
            try
            {
                var request = new AuthRequest();
                if (!request.IsAdminLoggin ||
                    !request.AdminPermissions.HasAdministratorPermissions(ConfigManager.SettingsPermissions.Admin))
                {
                    return Unauthorized();
                }

                var accessToken = TranslateUtils.DecryptStringBySecretKey(DataProvider.AccessTokenDao.Regenerate(id));

                return Ok(new
                {
                    Value = accessToken
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
