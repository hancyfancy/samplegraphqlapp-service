using SampleGraphqlApp.Data.Interface.Models.Complete;
using SampleGraphqlApp.Data.Interface.Models.Transient;
using System.Collections;

namespace SampleGraphqlApp.Service.Test.Suites
{
    public class GetAvailableBooksTestSuite : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            //Not populated
            yield return new object[] {
                $@"[]",
                new List<Student>() { }
            };

            //Populated
            yield return new object[] {
                $@"[
				    {{
					    ""id"": ""bok-103"",
					    ""name"": ""The Last Flair Bender"",
					    ""author"": ""Manny Abuduo"",
                        ""colleges"":null
				    }},
				    {{
					    ""id"": ""bok-105"",
					    ""name"": ""On the wild side"",
					    ""author"": ""Harriett Osbyorne"",
                        ""colleges"":null
				    }}
			    ]",
                new List<Student>() { 
                    new Student() { 
                        id = "S1003",
                        firstName = "Kiran",
                        lastName = "Panigrahi",
                        email = "kiran.panigrahi@tutorialpoint.org",
                        college = new College() { 
                            id = "col-101",
                            name = "AMU",
                            location = "Uttar Pradesh",
                            rating = 5.0,
                            books = new List<Book>() { 
                                new Book() { 
                                    id = "bok-103",
                                    name = "The Last Flair Bender",
                                    author = "Manny Abuduo"
                                },
                                new Book() { 
                                    id = "bok-105",
                                    name = "On the wild side",
                                    author = "Harriett Osbyorne"
                                }
                            }
                        }
                    }
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
