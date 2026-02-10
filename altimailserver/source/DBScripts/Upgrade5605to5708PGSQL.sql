ALTER TABLE hm_fetchaccounts ADD COLUMN famimerecipientheaders varchar(255) NOT NULL DEFAULT 'To,CC,X-RCPT-TO,X-Envelope-To';

insert into hm_settings (settingname, settingstring, settinginteger) values ('ImapMasterUser', '', 0);

insert into hm_settings (settingname, settingstring, settinginteger) values ('ImapAuthAllowPlainText', '', 0);

insert into hm_settings (settingname, settingstring, settinginteger) values ('EnableImapSASLPlain', '', 0);

insert into hm_settings (settingname, settingstring, settinginteger) values ('EnableImapSASLInitialResponse', '', 0);

alter table hm_accounts add column accountvacationabortspamflagged smallint not null;

alter table hm_accounts add column accountforwardabortspamflagged smallint not null;

alter table hm_rule_actions add column actionabortspamflagged smallint not null;

update hm_dbversion set value = 5708;
