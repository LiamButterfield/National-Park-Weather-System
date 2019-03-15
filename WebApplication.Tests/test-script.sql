-- Delete all of the surveys
DELETE FROM survey_result;

-- Delete all of the weather
DELETE FROM weather;

-- Delete all of the parks
DELETE FROM park;

-- Insert a fake park
INSERT INTO park VALUES ('XYZ', 'Xtreme Yoga Zoo', 'Ohio', 32832, 696, 125, 0, 
'Woodland', 2000, 2189849, 'Of all the paths you take in life, make sure a few of them are dirt.', 
'John Muir', 'Though a short distance from the urban areas of Cleveland and Akron...the end.', 0, 390);

-- Insert weather
INSERT INTO weather VALUES ('XYZ',1,38,62,'rain');
INSERT INTO weather VALUES ('XYZ',2,38,56,'partly cloudy');
INSERT INTO weather VALUES ('XYZ',3,51,66,'partly cloudy');
INSERT INTO weather VALUES ('XYZ',4,55,65,'rain');
INSERT INTO weather VALUES ('XYZ',5,53,69,'thunderstorms');

-- Insert a fake survey
INSERT INTO survey_result VALUES ('XYZ', 'npgeek@techelevator.com', 'OH', 'Sedantary');
DECLARE @newSurvey int = (SELECT @@IDENTITY);

-- Return the id of the fake city
SELECT @newSurvey as newSurveyId;