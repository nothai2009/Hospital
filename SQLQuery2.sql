select inv.code,s.specCode,s.specDesc,spec.*
from Med_inv_Spec spec 
INNER JOIN Med_inv inv ON inv.code=spec.abbr
INNER JOIN SPEC s ON s.specCode=spec.specCode
WHERE --inv.code='GNF0T1'
spec.abbr='GNF0T1'

--SELECT * FROM SPEC'ILPI2 '