# iosgames

# Available service end points
* Note: Requires authentication: requires that request contain valid apikey in its header authentication.
* AUTHORIZATION:
  - [/auth/register]
    It is allowed to annonimous users.
    Requires following form data:
      - username
      - password
      - firstname
      - lastname
      - email
  - [/auth/login]
    It is allowed to annonimous users.
    Requires following form data:
      - username
      - password
    After successfull verification returns session apikey.
  - [/auth/logout]
    Required apikey in request header authentication.

* ROOT:
  - [/]
    Requires authentication.
    Returns current service version.
