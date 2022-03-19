declare @articles int = 10
declare @clients int = 100
declare @invoices int = 1000
declare @c int = 0
declare @iLines int = 0
declare @cc int = 0
declare @furs int = 10
declare @lInvoice int = 0;

declare @articleP1 table (a nvarchar(10))
declare @articleP2 table (b nvarchar(10))
declare @clientP1 table (a nvarchar(10))
declare @clientP2 table (b nvarchar(10))
declare @clientP3 table (c nvarchar(10))

-- Insert misc variations
insert into @articleP1 values ('sok'), ('pivo'), ('voda');
insert into @articleP2 values ('čokoladno'), ('z okusom'), ('temno');
insert into @clientP1 values ('import'), ('export'), ('trgovina'), ('šola'), ('gostilna'), ('frizerstvo');
insert into @clientP2 values ('a'), ('b'), ('c'), ('č'), ('d'), ('e'), ('f');
insert into @clientP3 values ('Slovenska'), ('Dunajska'), ('Tržaška'), ('Šmartinska'), ('Celovška'), ('Litijska'), ('Dolenjska');


begin
    -- Insert article
    while @c < @articles
    begin
        insert into article (code, name, price) 
        select top 1 cast(rand() * 1000 as int), concat(concat(a, ' '), b), rand() * 1000
        from @articleP1, @articleP2
        order by newid();
        set @c = @c + 1;
    end;

    set @c = 0;

    -- Insert client
    while @c < @clients
    begin
        insert into client (tax_number, name, adddress, country) 
        select top 1 cast(rand() * 100000000 as int), concat(concat(a, ' '), b), concat(concat(c, ' '), cast(rand() * 100 as int)), case when rand() < 0.5 then 'SI' else 'HR' end
        from @clientP1, @clientP2, @clientP3
        order by newid();
        set @c = @c + 1;
    end;

    set @c = 0;

    -- Insert invoices
    while @c < @invoices
    begin
        insert into invoice ( furs_number, issue_date, id_client) 
        select top 1 concat('1-X-', format(@furs, '000000')), '2022-03-19', id
        from client
        order by newid();

        set @lInvoice = SCOPE_IDENTITY();
        set @iLines = cast(rand() * 5 as int);
        set @cc = 0;

        while @cc < @iLines
        begin
            insert into invoice_line (id_invoice, id_article, amount) 
            select top 1 @lInvoice, id, cast(rand() * 100 as int)
            from article
            order by newid();
            set @cc = @cc + 1;
        end;

        set @c = @c + 1;
        set @furs = @furs + 1;
    end;
end;