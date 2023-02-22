using SampleGraphqlApp.Data.Interface.Models.Complete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleGraphqlApp.Service.Test.Suites
{
    public class GetEnrolledCollegeTestSuite : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            //Not found
            yield return new object[] {
                $@"null",
                null
            };

            //Found
            yield return new object[] {
                $@"{{
		            ""id"": ""col-102"",
		            ""name"": ""CUSAT"",
		            ""location"": ""Kerala"",
		            ""rating"": 4.5,
		            ""books"": 
		            [
			            {{
				            ""id"": ""bok-102"",
				            ""name"": ""Knight and Bay"",
				            ""author"": ""Zon Drekka"",
                            ""colleges"":null
			            }},
			            {{
				            ""id"": ""bok-105"",
				            ""name"": ""On the wild side"",
				            ""author"": ""Harriett Osbyorne"",
                            ""colleges"":null
			            }},
			            {{
				            ""id"": ""bok-106"",
				            ""name"": ""Empty Space"",
				            ""author"": ""Xelvudi Trilchanov"",
                            ""colleges"":null
			            }}
		            ],
                    ""students"":null
	            }}",
                new Student() { 
                    id = "S1001",
                    firstName = "Mohtashim",
                    lastName = "Mohammad",
                    email = "mohtashim.mohammad@tutorialpoint.org",
                    college = new College() { 
                        id = "col-102",
                        name = "CUSAT",
                        location = "Kerala",
                        rating = 4.5,
                        books = new List<Book>() { 
                            new Book() { 
                                id = "bok-102",
                                name = "Knight and Bay",
                                author = "Zon Drekka"
                            },
                            new Book() { 
                                id = "bok-105",
                                name = "On the wild side",
                                author = "Harriett Osbyorne"
                            },
                            new Book() { 
                                id = "bok-106",
                                name = "Empty Space",
                                author = "Xelvudi Trilchanov"
                            }
                        }
                    }
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
