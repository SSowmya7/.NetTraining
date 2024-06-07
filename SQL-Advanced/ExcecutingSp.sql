-- Test case 1: No exclusions
EXEC sp_ExcludeYearModels;

-- Test case 2: Exclude only specific years
EXEC sp_ExcludeYearModels @ExcludeYears = '2021,2020';

-- Test case 3: Exclude specific year-model combinations
EXEC sp_ExcludeYearModels @ExcludeYearModels = '2021:Civic,2020:Sorento';

-- Test case 4: Exclude both specific years and year-model combinations
EXEC sp_ExcludeYearModels @ExcludeYears = '2023,2022', @ExcludeYearModels = '2020:Civic,2021:Sorento';
