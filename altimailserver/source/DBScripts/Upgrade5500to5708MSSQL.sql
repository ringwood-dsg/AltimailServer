insert into hm_settings (settingname, settingstring, settinginteger) values ('SmtpDeliveryConnectionSecurity', '', 2)

insert into hm_settings (settingname, settingstring, settinginteger) values ('VerifyRemoteSslCertificate', '', 1)

ALTER TABLE hm_settings ALTER COLUMN settingstring nvarchar(4000) NOT NULL

insert into hm_settings (settingname, settingstring, settinginteger) values ('SslCipherList', '', 0)

UPDATE hm_settings SET SettingString = 'ECDHE-RSA-AES128-GCM-SHA256:ECDHE-ECDSA-AES128-GCM-SHA256:ECDHE-RSA-AES256-GCM-SHA384:ECDHE-ECDSA-AES256-GCM-SHA384:DHE-RSA-AES128-GCM-SHA256:DHE-DSS-AES128-GCM-SHA256:kEDH+AESGCM:ECDHE-RSA-AES128-SHA256:ECDHE-ECDSA-AES128-SHA256:ECDHE-RSA-AES128-SHA:ECDHE-ECDSA-AES128-SHA:ECDHE-RSA-AES256-SHA384:ECDHE-ECDSA-AES256-SHA384:ECDHE-RSA-AES256-SHA:ECDHE-ECDSA-AES256-SHA:DHE-RSA-AES128-SHA256:DHE-RSA-AES128-SHA:DHE-DSS-AES128-SHA256:DHE-RSA-AES256-SHA256:DHE-DSS-AES256-SHA:DHE-RSA-AES256-SHA:AES128-GCM-SHA256:AES256-GCM-SHA384:ECDHE-RSA-RC4-SHA:ECDHE-ECDSA-RC4-SHA:AES128:AES256:RC4-SHA:HIGH:!aNULL:!eNULL:!EXPORT:!DES:!3DES:!MD5:!PSK;' WHERE SettingName = 'SslCipherList' AND SettingString = '';

insert into hm_settings (settingname, settingstring, settinginteger) values ('SslVersions', '', 15)

insert into hm_settings (settingname, settingstring, settinginteger) values ('ImapMasterUser', '', 0)

insert into hm_settings (settingname, settingstring, settinginteger) values ('ImapAuthAllowPlainText', '', 0)

insert into hm_settings (settingname, settingstring, settinginteger) values ('EnableImapSASLPlain', '', 0)

insert into hm_settings (settingname, settingstring, settinginteger) values ('EnableImapSASLInitialResponse', '', 0)

insert into hm_settings (settingname, settingstring, settinginteger) values ('ascheckptr', '', 0)

insert into hm_settings (settingname, settingstring, settinginteger) values ('ascheckptrscore', '', 1)

insert into hm_settings (settingname, settingstring, settinginteger) values ('IPv6Preferred', '', 0)

alter table hm_fetchaccounts add famimerecipientheaders nvarchar(255) not null default 'To,CC,X-RCPT-TO,X-Envelope-To'

insert into hm_settings (settingname, settingstring, settinginteger) values ('TlsOptions', '', 0)

alter table hm_accounts add accountvacationabortspamflagged tinyint not null default 0

alter table hm_accounts add accountforwardabortspamflagged tinyint not null default 0

alter table hm_rule_actions add actionabortspamflagged tinyint not null default 0

update hm_dbversion set value = 5708

