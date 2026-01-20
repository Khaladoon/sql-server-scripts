SELECT *
FROM GeneralSiteData
WHERE
    (@WellNo IS NULL OR WellNo LIKE '%' + @WellNo + '%')
AND (@Town IS NULL OR Town LIKE '%' + @Town + '%')
AND (@Owner IS NULL OR OwnerName LIKE '%' + @Owner + '%')
AND (@MinDepth IS NULL OR TotalDepth >= @MinDepth)
AND (@MaxDepth IS NULL OR TotalDepth <= @MaxDepth);
