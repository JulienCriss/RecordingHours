alter session set "_ORACLE_SCRIPT"=true;
SET SERVEROUTPUT ON;

---------ROL ANGAJAT------------
CREATE ROLE rol_angajat;
GRANT SELECT,UPDATE ON userDBA.ANGAJATI TO rol_angajat;
GRANT SELECT,UPDATE ON userDBA.ANGAJATI_COMPETENTE TO rol_angajat;
GRANT SELECT ON userDBA.PROIECTE_COMPETENTE TO rol_angajat;
GRANT SELECT ON userDBA.COMPETENTE TO rol_angajat;
GRANT SELECT ON userDBA.DEPARTAMENTE TO rol_angajat;
GRANT SELECT,INSERT,UPDATE,DELETE ON userDBA.PONTAJ TO rol_angajat;
GRANT SELECT,UPDATE ON userDBA.PROIECTE TO rol_angajat;
GRANT create session TO rol_angajat;

DECLARE
  var_ang_nume angajati.ang_nume%type;
  CURSOR cursor_drepturi_ang IS 
    SELECT ang_nume from angajati where ang_data_parasire is null;
    
    BEGIN
      OPEN cursor_drepturi_ang;
      LOOP
        FETCH cursor_drepturi_ang INTO var_ang_nume;
        EXIT WHEN cursor_drepturi_ang%NOTFOUND OR
        cursor_drepturi_ang%NOTFOUND IS NULL;
        
        EXECUTE IMMEDIATE 'CREATE USER ' || lower(var_ang_nume) || ' IDENTIFIED BY ' || lower(var_ang_nume);
        EXECUTE IMMEDIATE 'GRANT rol_angajat TO ' || lower(var_ang_nume);
        
        dbms_output.put_line('GRANT ROLE FOR --> ' || lower(var_ang_nume));
      END LOOP;
      CLOSE cursor_drepturi_ang;
    END;
    
COMMIT;
SELECT * FROM session_roles;
