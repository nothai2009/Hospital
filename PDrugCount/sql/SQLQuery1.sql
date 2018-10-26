SELECT abbr, hideSelect, RTRIM(gen_name)AS gen_name,RTRIM(dform)AS dform, RTRIM(strgth)AS strgth, RTRIM(strgth_u)AS strgth_u, LTRIM(RTRIM(opd_prc))AS opd_prc, p.ed_group, ed_list, prod_type, AutoStop
FROM Med_inv i
LEFT JOIN PRODTYPE p WITH (NOLOCK) ON i.prod_type=p.prdTypeCode
WHERE abbr +' ' + gen_name LIKE '%%'

SELECT * FROM PRODTYPE

UPDATE Med_inv SET
abbr='', hideSelect='', gen_name='',dform='',strgth='', strgth_u='', opd_prc='', ed_group='', ed_list='', prod_type='', AutoStop=''
WHERE abbr='ABC3T2'