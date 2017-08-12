CREATE OR REPLACE PACKAGE ADMIN_PACKAGE IS
  FUNCTION
  FUNC_ADAUGA_ANGAJAT(
  id_angajat IN angajati.ang_id%TYPE,
  nume_angajat IN angajati.ang_nume%TYPE,
  prenume_angajat IN angajati.ang_prenume%TYPE,
  sal_angajat IN angajati.ang_salariu%TYPE,
  data_angajare IN angajati.ang_data_angajare%TYPE,
  id_departament IN angajati.dept_id%TYPE,
  competenta_id IN angajati_competente.comp_id%TYPE
  )
  -- return 0: introducere cu succes
  -- return 1: angajatul deja exista
  RETURN INTEGER;
  
  FUNCTION
  FUNC_UPDATE_COMP(
  id_angajat angajati_competente.ang_id%TYPE,
  id_comp angajati_competente.comp_id%TYPE)
  RETURN INTEGER;
  
  FUNCTION
  FUNC_EDITEAZA_ANGAJAT(
  id_angajat angajati.ang_id%TYPE,
  salariu_angajat angajati.ang_salariu%TYPE,
  id_dept angajati.dept_id%TYPE)
  RETURN INTEGER;
  
  PROCEDURE
  PROC_DELETE_ANGAJAT(
  id_angajat angajati.ang_id%TYPE);
END ADMIN_PACKAGE;
/
CREATE OR REPLACE PACKAGE BODY ADMIN_PACKAGE IS
  FUNCTION
  FUNC_ADAUGA_ANGAJAT(
  id_angajat IN angajati.ang_id%TYPE,
  nume_angajat IN angajati.ang_nume%TYPE,
  prenume_angajat IN angajati.ang_prenume%TYPE,
  sal_angajat IN angajati.ang_salariu%TYPE,
  data_angajare IN angajati.ang_data_angajare%TYPE,
  id_departament IN angajati.dept_id%TYPE,
  competenta_id IN angajati_competente.comp_id%TYPE
  )
  -- return 0: introducere cu succes
  -- return 1: angajatul deja exista
  RETURN INTEGER
  IS
  CURSOR my_cursor IS
    SELECT * FROM ANGAJATI 
    WHERE ang_id = id_angajat 
    OR ang_nume = nume_angajat OR ang_prenume = prenume_angajat;
  
    flag INTEGER;
    var_contor NUMBER:=0;
    aux_cursor my_cursor%ROWTYPE;
  BEGIN
    --verifica daca angajatul exista deja
    OPEN my_cursor;
    LOOP
      FETCH my_cursor INTO aux_cursor;
      EXIT WHEN my_cursor%NOTFOUND;
      var_contor := var_contor + 1;
    END LOOP;
    CLOSE my_cursor;
    
    IF var_contor = 0 THEN
      -- insereaza in angajati
      INSERT INTO angajati (ang_id, ang_nume, ang_prenume, ang_salariu, ang_data_angajare, ang_data_parasire, dept_id)
      VALUES (id_angajat, nume_angajat, prenume_angajat, sal_angajat, data_angajare, null, id_departament);
      
      -- acorda roluri
      --EXECUTE IMMEDIATE 'ALTER SESSION SET "_ORACLE_SCRIPT"=true';
      --EXECUTE IMMEDIATE 'CREATE USER ' || lower(nume_angajat) || ' IDENTIFIED BY ' || lower(nume_angajat);
      --EXECUTE IMMEDIATE 'GRANT rol_angajat TO ' || lower(nume_angajat);
      
      -- insereaza in competente
      INSERT INTO angajati_competente (ang_id, comp_id)
      VALUES(id_angajat, competenta_id);
      COMMIT;
      flag := 0;
      RETURN flag;
    ELSE
      flag := 1;
      RETURN flag;
    END IF;
  END FUNC_ADAUGA_ANGAJAT;
  
  FUNCTION
  FUNC_UPDATE_COMP(
  id_angajat angajati_competente.ang_id%TYPE,
  id_comp angajati_competente.comp_id%TYPE)
  RETURN INTEGER
  IS
    flag INTEGER;
  BEGIN
    -- insereaza in competente
    INSERT INTO angajati_competente (ang_id, comp_id)
    VALUES(id_angajat, id_comp);
    COMMIT;
    flag := 0;
    RETURN flag;
  END FUNC_UPDATE_COMP;
  
  FUNCTION
  FUNC_EDITEAZA_ANGAJAT(
  id_angajat angajati.ang_id%TYPE,
  salariu_angajat angajati.ang_salariu%TYPE,
  id_dept angajati.dept_id%TYPE)
  RETURN INTEGER
  IS
    flag INTEGER;
  BEGIN 
    UPDATE angajati SET ang_salariu = salariu_angajat, dept_id = id_dept WHERE ang_id = id_angajat;
    COMMIT;
    flag := 0;
    RETURN flag;
  END FUNC_EDITEAZA_ANGAJAT;
  
  PROCEDURE
  PROC_DELETE_ANGAJAT(
  id_angajat angajati.ang_id%TYPE)
  IS
  BEGIN
    UPDATE angajati SET ang_data_parasire = CURRENT_DATE WHERE ang_id = id_angajat;
    COMMIT;
  END PROC_DELETE_ANGAJAT;
END ADMIN_PACKAGE;
/
GRANT EXECUTE ON ADMIN_PACKAGE TO admin_ang;
/
CREATE OR REPLACE PACKAGE ANGAJAT_PACKAGE IS
  FUNCTION
  FUNC_ANGAJAT_SALAR(
    var_ang_id IN angajati.ang_id%TYPE)
    RETURN NUMBER;
-----------------------------------------
  FUNCTION 
  FUNC_ADAUGA_PONTAJ(
    dataPontaj IN pontaj.pontaj_zi%TYPE,
    oraStart IN pontaj.pontaj_ora_start%TYPE,
    oraStop IN pontaj.pontaj_ora_end%TYPE,
    idProiect IN pontaj.pro_id%TYPE,
    numeAngajat IN angajati.ang_nume%TYPE, 
    pro_ore_efec IN proiecte.pro_ore_efectuate%TYPE)
    -- return 0 --> intorducere cu succes
    -- return 1 --> eroare : se suprapun pontaje
    -- return 2 --> eroare : numarul toatal de ore pontate pe ziua respectiva, depaseste 8 ore
    -- return 3 --> eroare : data not found
    RETURN INTEGER;
  FUNCTION
  FUNC_STERGE_PONTAJ(
    dataPontaj IN pontaj.pontaj_zi%TYPE,
    oraStart IN pontaj.pontaj_ora_start%TYPE,
    oraStop IN pontaj.pontaj_ora_end%TYPE,
    proiect_nume IN proiecte.pro_nume%TYPE,
    numeAngajat IN angajati.ang_nume%TYPE,
    pro_ore_efec IN proiecte.pro_ore_efectuate%TYPE)
    
    RETURN INTEGER;
  FUNCTION
  FUNC_EDITEAZA_PONTAJ(
    dataPontaj IN pontaj.pontaj_zi%TYPE,
    numeAngajat IN angajati.ang_nume%TYPE,
    idProiect IN pontaj.pro_id%TYPE,
    oldOraStart IN pontaj.pontaj_ora_start%TYPE,
    oldOraStop IN pontaj.pontaj_ora_end%TYPE,
    newOraStart IN pontaj.pontaj_ora_start%TYPE,
    newOraStop IN pontaj.pontaj_ora_end%TYPE,
    old_pro_ore_efec IN proiecte.pro_ore_efectuate%TYPE,
    new_pro_ore_efec IN proiecte.pro_ore_efectuate%TYPE
    )
  -- return 0 --> intorducere cu succes
  -- return 1 --> eroare : se suprapun pontaje
  -- return 2 --> eroare : data not found
  RETURN INTEGER;
END ANGAJAT_PACKAGE;
/
CREATE OR REPLACE PACKAGE BODY ANGAJAT_PACKAGE IS
  FUNCTION
  FUNC_CALC_WORK_DAYS(
    var_date DATE
  )
  RETURN INTEGER
  IS
    var_dat1 date;
    var_dat2 date;
    var_number integer := 0;
    i integer := 1;
  BEGIN
    select LAST_DAY(ADD_MONTHS(var_date, -1)) into var_dat2 from dual;
    select trunc(to_date(ADD_MONTHS(var_date, -1), 'DD/MM/YYYY'), 'MM') into var_dat1 from dual;
    LOOP
       IF (NOT to_char(var_dat1, 'd', 'NLS_DATE_LANGUAGE = english') = '1') AND
        (NOT to_char(var_dat1, 'd', 'NLS_DATE_LANGUAGE = english') = '7') THEN
          var_number := var_number + 1;
        END IF;
       var_dat1 := var_dat1 + 1;
       i := i+1;
       EXIT WHEN i >= extract(day from var_dat2);
    END LOOP;
    RETURN var_number;
  END FUNC_CALC_WORK_DAYS;
--------------------------------------------------------------
  FUNCTION
  FUNC_ANGAJAT_SALAR(
    var_ang_id IN angajati.ang_id%TYPE)
    RETURN NUMBER
    IS
      v_salar_default angajati.ang_salariu%TYPE;
      v_salar NUMBER(6,2);
      var_ore_pontate INTEGER;
    BEGIN
      SELECT SUM(pontaj_ora_end-pontaj_ora_start) INTO var_ore_pontate FROM pontaj WHERE ang_id = var_ang_id 
        AND to_char(pontaj_zi,'MM') = to_char(ADD_MONTHS(SYSDATE, -1),'MM');
      SELECT ang_salariu INTO v_salar_default FROM angajati WHERE ang_id = var_ang_id;
      v_salar := var_ore_pontate*(v_salar_default/((FUNC_CALC_WORK_DAYS(SYSDATE)*8.0)));
      return v_salar;
  END FUNC_ANGAJAT_SALAR;
-------------------------------------------------------------
--------------------------------------------------------------
  FUNCTION 
  FUNC_ADAUGA_PONTAJ(
    dataPontaj IN pontaj.pontaj_zi%TYPE,
    oraStart IN pontaj.pontaj_ora_start%TYPE,
    oraStop IN pontaj.pontaj_ora_end%TYPE,
    idProiect IN pontaj.pro_id%TYPE,
    numeAngajat IN angajati.ang_nume%TYPE, 
    pro_ore_efec IN proiecte.pro_ore_efectuate%TYPE)
    -- return 0 --> intorducere cu succes
    -- return 1 --> eroare : se suprapun pontaje
    -- return 2 --> eroare : numarul toatal de ore pontate pe ziua respectiva, depaseste 8 ore
    -- return 3 --> eroare : data not found
    RETURN INTEGER
    IS
    CURSOR my_cursor IS
      SELECT * FROM PONTAJ
      WHERE to_date(pontaj_zi) = to_date(dataPontaj) 
      AND (pontaj_ora_start >= oraStart and pontaj_ora_start < oraStop OR pontaj_ora_end > oraStart AND pontaj_ora_end <= oraStop)
      AND ang_id = (SELECT ang_id FROM angajati where lower(ang_nume) = numeAngajat);
    
    var_contor_pontaje NUMBER;
    var_contor NUMBER:=0;
    aux_cursor my_cursor%ROWTYPE;
    
    flag INTEGER;
    var_angajatID angajati.ang_id%TYPE;
    var_total_ore pontaj.pontaj_ora_start%TYPE;
    var_pro_ore_efectuate proiecte.pro_ore_efectuate%TYPE;
    BEGIN
      -- verifica daca intervalul nou suprapune ore deja pontate
      OPEN my_cursor;
      LOOP
        FETCH my_cursor into aux_cursor;
        EXIT WHEN my_cursor%NOTFOUND;
        var_contor := var_contor +1;
      END LOOP;
      dbms_output.put_line('aaaaa -> ' || var_contor);
      CLOSE my_cursor;
      -- daca contorul este zero, atunci nu sunt ore care se suprapun
      IF var_contor = 0 THEN
        -- selecteaza id-ul angajatului
        SELECT ang_id 
        INTO var_angajatID
        FROM userDBA.angajati
        WHERE lower(ang_nume) = numeAngajat;
        
        -- calculeaza numarul de ore pe ziua respectiva
        SELECT sum(pontaj_ora_end - pontaj_ora_start)
        INTO var_total_ore
        FROM pontaj
        WHERE to_date(pontaj_zi) = to_date(dataPontaj) AND ang_id = var_angajatID;
        
        -- selecteaza orele efectuate deja pe proiect
        -- necesare la update
        SELECT pro_ore_efectuate
        INTO var_pro_ore_efectuate
        FROM proiecte
        WHERE pro_id = idProiect;
        
        var_total_ore := var_total_ore + oraStop - oraStart;
        IF var_total_ore > 8 THEN
          flag := 2;
          RETURN flag;
        ELSE
          -- insereaza in tabela pontaj
          INSERT INTO PONTAJ VALUES(dataPontaj, oraStart, oraStop, var_angajatID, idProiect);
          -- update pe ore_efectuate pentru proiectul in cauza
          UPDATE proiecte SET pro_ore_efectuate = var_pro_ore_efectuate + pro_ore_efec WHERE pro_id = idProiect; 
          COMMIT;
          flag := 0;
          RETURN flag;
        END IF;
        --END IF;
      ELSE
        flag := 1;
        RETURN flag;
      END IF;
      
      EXCEPTION
        WHEN NO_DATA_FOUND THEN
          flag := 3;
          RETURN flag;
  END FUNC_ADAUGA_PONTAJ;
  FUNCTION
  FUNC_STERGE_PONTAJ(
    dataPontaj IN pontaj.pontaj_zi%TYPE,
    oraStart IN pontaj.pontaj_ora_start%TYPE,
    oraStop IN pontaj.pontaj_ora_end%TYPE,
    proiect_nume IN proiecte.pro_nume%TYPE,
    numeAngajat IN angajati.ang_nume%TYPE,
    pro_ore_efec IN proiecte.pro_ore_efectuate%TYPE)
    
    RETURN INTEGER
    IS
    flag INTEGER;
    var_angajatID angajati.ang_id%TYPE;
    var_id_proiect proiecte.pro_id%TYPE;
    var_pro_ore_efectuate proiecte.pro_ore_efectuate%TYPE;
    BEGIN
    
      -- selecteaza id-ul angajatului
      SELECT ang_id 
      INTO var_angajatID
      FROM userDBA.angajati
      WHERE lower(ang_nume) = numeAngajat;
      
      -- slecteaza id-ul proiectului
      SELECT pro_id
      INTO var_id_proiect
      FROM proiecte
      WHERE pro_nume = proiect_nume;
      
      -- selecteaza orele efectuate deja pe proiect
      -- necesare la update
      SELECT pro_ore_efectuate
      INTO var_pro_ore_efectuate
      FROM proiecte
      WHERE pro_id = var_id_proiect;
      
      -- sterge pontaj
      DELETE FROM PONTAJ
      WHERE to_date(pontaj_zi) = to_date(dataPontaj)
      AND ang_id = var_angajatID
      AND pro_id = var_id_proiect
      AND pontaj_ora_start = oraStart
      AND pontaj_ora_end = oraStop;
      -- update ore proiect
      UPDATE proiecte SET pro_ore_efectuate = var_pro_ore_efectuate - pro_ore_efec WHERE pro_id = var_id_proiect;
      COMMIT;
      
      flag := 1;
      RETURN flag;
      
      EXCEPTION
        WHEN NO_DATA_FOUND THEN
          flag := 0;
          RETURN flag;
    
  END FUNC_STERGE_PONTAJ;
  FUNCTION
  FUNC_EDITEAZA_PONTAJ(
    dataPontaj IN pontaj.pontaj_zi%TYPE,
    numeAngajat IN angajati.ang_nume%TYPE,
    idProiect IN pontaj.pro_id%TYPE,
    oldOraStart IN pontaj.pontaj_ora_start%TYPE,
    oldOraStop IN pontaj.pontaj_ora_end%TYPE,
    newOraStart IN pontaj.pontaj_ora_start%TYPE,
    newOraStop IN pontaj.pontaj_ora_end%TYPE,
    old_pro_ore_efec IN proiecte.pro_ore_efectuate%TYPE,
    new_pro_ore_efec IN proiecte.pro_ore_efectuate%TYPE
    )
  -- return 0 --> intorducere cu succes
  -- return 1 --> eroare : se suprapun pontaje
  -- return 2 --> eroare : data not found
  RETURN INTEGER
  IS
  CURSOR my_cursor IS
      SELECT * FROM PONTAJ
      WHERE to_date(pontaj_zi) = to_date(dataPontaj) 
      AND (pontaj_ora_start >= newOraStart and pontaj_ora_start < newOraStop OR pontaj_ora_end > newOraStart AND pontaj_ora_end <= newOraStop)
      AND ang_id = (SELECT ang_id FROM angajati where lower(ang_nume) = numeAngajat);
    
    var_contor NUMBER:=0;
    aux_cursor my_cursor%ROWTYPE;
    
    flag INTEGER;
    var_angajatID angajati.ang_id%TYPE;
    var_total_ore pontaj.pontaj_ora_start%TYPE;
    var_old_pro_ore_efectuate proiecte.pro_ore_efectuate%TYPE;
    var_ore_pe_proiect proiecte.pro_ore_efectuate%TYPE;
  BEGIN
    -- verifica daca intervalul nou suprapune ore deja pontate
    OPEN my_cursor;
    LOOP
      FETCH my_cursor into aux_cursor;
      EXIT WHEN my_cursor%NOTFOUND;
      var_contor := var_contor +1;
    END LOOP;
    dbms_output.put_line('aaaaa -> ' || var_contor);
    CLOSE my_cursor;
    -- verifica daca editarea suprapune alte ore deja existente
    IF var_contor = 0 THEN
      -- selecteaza id-ul angajatului
      SELECT ang_id 
      INTO var_angajatID
      FROM userDBA.angajati
      WHERE lower(ang_nume) = numeAngajat;
  
      -- calculeaza numarul de ore pe ziua respectiva
      SELECT sum(pontaj_ora_end - pontaj_ora_start)
      INTO var_total_ore
      FROM pontaj
      WHERE to_date(pontaj_zi) = to_date(dataPontaj) AND ang_id = var_angajatID;
  
      -- selecteaza orele efectuate deja pe proiect
      -- necesare la update
      SELECT pro_ore_efectuate
      INTO var_old_pro_ore_efectuate
      FROM proiecte
      WHERE pro_id = idProiect;
      -- calculez orele de pe proiect 
      var_ore_pe_proiect := var_old_pro_ore_efectuate - old_pro_ore_efec + new_pro_ore_efec;
      IF var_ore_pe_proiect < 0 THEN
        var_ore_pe_proiect := 0;
      END IF;
      -- update tabela pontaj
      UPDATE PONTAJ SET pontaj_ora_start = newOraStart, pontaj_ora_end = newOraStop
      WHERE pro_id = idProiect AND ang_id = var_angajatID AND to_date(pontaj_zi) = to_date(dataPontaj) AND pontaj_ora_start = oldOraStart AND pontaj_ora_end = oldOraStop;
      
      -- update tabela de proiecte
      UPDATE proiecte SET pro_ore_efectuate = var_ore_pe_proiect WHERE pro_id = idProiect;
      COMMIT;
      flag := 0;
      RETURN flag;
    ELSE
      flag := 1;
      RETURN flag;
    END IF;
    EXCEPTION
      WHEN NO_DATA_FOUND THEN
        flag := 2;
        RETURN flag;
  END FUNC_EDITEAZA_PONTAJ;
END ANGAJAT_PACKAGE;
/
GRANT EXECUTE ON ANGAJAT_PACKAGE TO rol_angajat;
/
alter session set "_ORACLE_SCRIPT"=true;
/
commit;
/
select * from proiecte;
/
CREATE OR REPLACE TRIGGER TGR_PONTAJ_STADIU
  BEFORE INSERT OR UPDATE OR DELETE ON proiecte
  FOR EACH ROW
  BEGIN
    IF :new.pro_ore_estimate <= :new.pro_ore_efectuate THEN
      :new.pro_stadiu := 'depasit';
    else
      :new.pro_stadiu := 'deschis';
    END IF;
END TGR_PONTAJ_STADIU;
/
commit;
/
