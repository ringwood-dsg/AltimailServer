insert into hm_settings (settingname, settingstring, settinginteger) values ('SslVersions', '', 15);

insert into hm_settings (settingname, settingstring, settinginteger) values ('ImapMasterUser', '', 0);

insert into hm_settings (settingname, settingstring, settinginteger) values ('ImapAuthAllowPlainText', '', 0);

insert into hm_settings (settingname, settingstring, settinginteger) values ('EnableImapSASLPlain', '', 0);

insert into hm_settings (settingname, settingstring, settinginteger) values ('EnableImapSASLInitialResponse', '', 0);

insert into hm_settings (settingname, settingstring, settinginteger) values ('ascheckptr', '', 0);

insert into hm_settings (settingname, settingstring, settinginteger) values ('ascheckptrscore', '', 1);

insert into hm_settings (settingname, settingstring, settinginteger) values ('IPv6Preferred', '', 0);

alter table hm_fetchaccounts add column famimerecipientheaders varchar(255) not null default 'To,CC,X-RCPT-TO,X-Envelope-To';

insert into hm_settings (settingname, settingstring, settinginteger) values ('TlsOptions', '', 0);

alter table hm_accounts add column accountvacationabortspamflagged tinyint not null;

alter table hm_accounts add column accountforwardabortspamflagged tinyint not null;

alter table hm_rule_actions add column actionabortspamflagged tinyint not null;

alter table hm_messages modify column messageflags tinyint unsigned not null;

update hm_dbversion set value = 5708;