alter table hm_fetchaccounts add column famimerecipientheaders varchar(255) not null default 'To,CC,X-RCPT-TO,X-Envelope-To';

update hm_dbversion set value = 5704