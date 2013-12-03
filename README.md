centralized-validation 
======================

Show a way to centralize your use of DataAnnotations 

When using ASP.NET MVC there is a problem with sharing DataAnnotation between viewmodels and DTO's or entities. I sovled this problem by creating a custom attribute and a custom Metadata
Provider.

How it works
============

In this solution you will find a UserViewModel and a UserEntity both sharing the same DataAnnotations validation rules.

First I created an attribute (MetadataLocationAttribute) wich allows you to specify in wich class to look for the centralized validation rules. Then I created a 
custom meta data provider wich when MVC is looking for DataAnnotations we have a change to tell MVC where too look for it. Last but not least I have added a generic
Validator class which can using the attribute to locate and use the centralized validatio rules to validate a given object.