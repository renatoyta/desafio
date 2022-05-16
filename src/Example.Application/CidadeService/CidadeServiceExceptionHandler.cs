using Microsoft.Data.SqlClient;

namespace Example.Application.CidadeService.Service
{
    public class CidadeServiceExceptionHandler
    {
        public void HandleCidadeException(Exception ex)
        {
            if (ex.InnerException != null)
                if (ex.InnerException is SqlException sqlException)
                {
                    switch (sqlException.Number)
                    {
                    case 2627:  // Unique constraint error
                    case 547:   // Constraint check violation
                    case 2601:  // Duplicated key row error

                    throw new Exception(ex.InnerException.Message);
                    }
                }
            throw ex;
        }
    }
}