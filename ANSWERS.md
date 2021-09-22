### Answers

## Exercise 4
Explain some of the key differences between the three and give examples of where you would use each of them.

1. Class... is the most common data type, and usually the safest bet. If immutability is not something you're looking for, and you're looking for inheritance, or something that doesn't really fit the struct data type, then classes is what you'd be using. Classes are a good idea to use when ..
1. Struct... is a value data type that is used to represent data structures. Structs are usually used to contain small data values, that e.g. don't require inheritance. You would use a Struct for e.g. a location struct with XYZ values, a vector, etc. 
1. Records... are generally the same as regular classes, however, one of the key differences is that they allow for immutability for reference types and use value based equality. Records also provides the ability to copy an object while adding the option to override specific fields from the object. This is achieved by using the 'with' keyword. It's worth noting that records can inherit other records, but cannot inherit other classes. You would use a Record for e.g. has table keys, as you ensure that the object is immutaable.