using BeSharpGym.Data;
using BeSharpGym.Dto;
using BeSharpGym.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeSharpGym.Controllers;

[ApiController]
[Route("[controller]")]
public class MemberController : ControllerBase
{
    DataContexDapper _dapper;

    public MemberController (IConfiguration config)
    {
        _dapper = new DataContexDapper(config);
    }

   [HttpGet("GetMembers")]

   public IEnumerable<Member> GetMembers()
   {
        string sql = @"
            SELECT [MemberId],
                [FullName],
                [Email],
                [RegistrationDate],
                [LastLoginDate],
                [IsPremiumMember],
                [MembershipStatus]
            FROM Members";

        IEnumerable<Member> members = _dapper.LoadData<Member>(sql);
        return members;
   }

     [HttpGet("GetSingleMember/{MemberId}")]
     public Member GetSingleUser(int MemberId)
     {
        string sql = @"
            SELECT [MemberId],
                [FullName],
                [Email],
                [RegistrationDate],
                [LastLoginDate],
                [IsPremiumMember],
                [MembershipStatus]
            FROM Members 
                WHERE [MemberId] = " + MemberId.ToString();

        Member member = _dapper.LoadDataSingle<Member>(sql);
        return member;
     }

     [HttpPut("EditMember")]
     public IActionResult EditMember(Member member)
     {
        string sql = @"
        UPDATE Members
            SET [FullName] = '" + member.FullName + 
            "', [Email] = '" + member.Email +
            "', [RegistrationDate] = '" + member.RegistrationDate +
            "',  [LastLoginDate] = '" + member.LastLoginDate +
            "',  [IsPremiumMember] = '" + member.IsPremiumMember +
            "', [MembershipStatus] = '" + member.MembershipStatus +
            "'  WHERE MemberId = " + member.MemberId;

            if(_dapper.ExecuteSql(sql))
        {
            return Ok();
        }

        throw new Exception("Failed to Update Member");
     }


     [HttpPost("AddMember")]
     public IActionResult AddMember(MemberDto member)
     {

        string sql = @" INSERT INTO Members(
        [FullName],
        [Email],
        [RegistrationDate],
        [LastLoginDate],
        [IsPremiumMember],
        [MembershipStatus] ) 
    VALUES (" +
        "'" + member.FullName + 
        "', '" + member.Email +
        "', '" + member.RegistrationDate +
        "', '" + member.LastLoginDate +
        "', '" + member.IsPremiumMember +
        "', '" + member.MembershipStatus + 
        "')";

        if (_dapper.ExecuteSql(sql))
    {
        return Ok();
    }
    throw new Exception("Failed to Add Member");    
     }

     [HttpDelete("DeleteUser/{MemberId}")]
    public IActionResult DeleteMember (int MemberId)
     {
        string sql = @"
        DELETE FROM Members 
        WHERE MemberId = " + MemberId.ToString();

         if (_dapper.ExecuteSql(sql))
    {
        return Ok();
    }
    throw new Exception("Failed to Delete Member"); 
     }
}
