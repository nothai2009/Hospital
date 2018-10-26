SELECT abbr, hideSelect, RTRIM(gen_name)AS gen_name,RTRIM(dform)AS dform, RTRIM(strgth)AS strgth, RTRIM(strgth_u)AS strgth_u, LTRIM(RTRIM(opd_prc))AS opd_prc, p.ed_group, ed_list, prod_type, AutoStop
FROM Med_inv i
LEFT JOIN PRODTYPE p WITH (NOLOCK) ON i.prod_type=p.prdTypeCode
WHERE abbr +' ' + gen_name LIKE '%%'

SELECT * FROM Med_inv

--UPDATE Med_inv SET
--abbr='', hideSelect='', gen_name='',dform='',strgth='', strgth_u='', opd_prc='', ed_group='', ed_list='', prod_type='', AutoStop=''
--WHERE abbr='ABC3T2'


SELECT * FROM Ward_dept

select s.specCode,s.specDesc
from SPEC s

SELECT [id],[Des] FROM Med_inv_ed_List

SELECT dform_key,dform_des FROM dbo.Dform

SELECT code, abbr, hideSelect,LTRIM(RTRIM(gen_name)) AS gen_name, LTRIM(RTRIM(name)) AS name, RTRIM(dform)AS dform, RTRIM(strgth)AS strgth, RTRIM(strgth_u)AS strgth_u,ltrim(opd_prc)AS opd_prc,prdTypeDesc,[Des],ed_group,AutoStop,prdTypeCode  FROM Med_inv inv  LEFT JOIN[PRODTYPE] pt WITH(NOLOCK) ON inv.prod_type = pt.[prdTypeCode]   LEFT JOIN [Med_inv_ed_List] ml WITH(NOLOCK) ON ml.id=inv.ed_list WHERE code ='5FUED '
