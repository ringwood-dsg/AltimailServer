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

