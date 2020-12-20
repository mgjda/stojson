# stojson

STOJSON is acronym arised from "words separated by Semicolon TO JSON".

I created it for convert file that is formatted like this:
```bash
word1;synonym1;synonym2
word2;synonym1
etc.
```
to Json format:
```json
[
    {
        "Name": "word1",
        "Synonyms": [
            "synonym1",
            "synonym2",
        ]
    },
    {
        "Name": "word2",
        "Synonyms": [
            "synonym1"
        ]
    }
	etc.
]
```

Works for CRLF file encoding.

File that i used included.
## Usage
For Windows after compile:
```bash
.\stojson.exe .\file.txt
```